using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MyApi.Extensions;
using MyApi.Middlewares;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

#region Serilog config

// builder.Host.UseSerilog((context, services, configuration) =>
// {
//     configuration
//         .ReadFrom.Configuration(context.Configuration)
//         .ReadFrom.Services(services)
//         .Enrich.FromLogContext();
// });
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{environment}.json", optional: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()

        // Console sink: Geliştirme ortamında tüm loglar (Information ve üstü)
        .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)

        // PostgreSQL sink: Sadece Error ve üstü loglar
        .WriteTo.PostgreSQL(
            connectionString: context.Configuration.GetConnectionString("PostgreSQLConnection"),
            tableName: "logs",
            needAutoCreateTable: true,
            restrictedToMinimumLevel: LogEventLevel.Error
        );
});

#endregion
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(x => x.Value!.Errors.Count > 0)
                .Select(x => new
                {
                    Field = x.Key,
                    Errors = x.Value!.Errors.Select(e => e.ErrorMessage)
                });

            return new BadRequestObjectResult(new
            {
                Message = "Validation hatası",
                Errors = errors
            });
        };
    });


// [CORS (Cross-Origin Resource Sharing)]
// Tarayıcı güvenliği nedeniyle, farklı bir adresten (örn: localhost:3000'deki React projen) 
// bu API'ye istek atılmasını engellememek için "AllowAll" (Her şeye izin ver) politikası oluşturuyoruz.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()   // Herhangi bir kaynaktan gelen isteğe izin ver
              .AllowAnyMethod()   // GET, POST, PUT, DELETE hepsine izin ver
              .AllowAnyHeader()); // Her türlü Header (Content-Type vb.) bilgisine izin ver
});

// [Endpoint Explorer]
// Uygulamadaki tüm API rotalarını tarar ve Swagger'ın bunları listelemesine yardımcı olur.
builder.Services.AddEndpointsApiExplorer();

// [Swagger / OpenAPI Yapılandırması]
// API dokümantasyon sayfasının nasıl görüneceğini ve özelliklerini belirleriz.
builder.Services.AddSwaggerGen(options =>
{
    // API'nin başlığı, versiyonu ve açıklaması
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mustafa Barış Solak Portfolio API",
        Version = "v1",
        Description = "Portfolyo projesi için backend API dokümantasyonu."
    });

    // [JWT Auth Tanımı]
    // Swagger arayüzünde "Authorize" butonu çıkmasını sağlar. 
    // Bu sayede kilit simgesine tıklayıp Token girebilirsin.
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Token girerken 'Bearer ' yazmanıza gerek yok, sadece tokenı yapıştırın."
    });

    // [Güvenlik Gereksinimi]
    // Swagger'daki tüm endpoint'lerin yanına o kilit simgesini koyar.
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

// --- AYARLAR BİTTİ, UYGULAMAYI İNŞA ET ---
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseSerilogRequestLogging();
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();