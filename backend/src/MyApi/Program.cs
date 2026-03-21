using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyApi.Context;
using MyApi.Managers.Abstracts;
using MyApi.Managers.Concretes;
using MyApi.Repositories.Abstracts;
using MyApi.Repositories.Concretes;

var builder = WebApplication.CreateBuilder(args); // Uygulamanın yapılandırıcısını başlatır (Ayarlar, Servisler burada toplanır).

builder.Services.AddDbContext<AppDbContext>(opt =>
                    opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));

// --- 1. SERVİS KAYITLARI (DEPENDENCY INJECTION - DI) ---
// Burada uygulamada kullanılacak "araçları" sisteme tanıtıyoruz.
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IAboutMeRepository, AboutMeRepository>();

builder.Services.AddScoped<IAboutMeManager, AboutMeManager>();


// [Controller Desteği]
// Minimal API yerine [ApiController] attribute'u kullanılan sınıfları (Controllers klasörü) tanımasını sağlar.
builder.Services.AddControllers();

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

// --- 2. MIDDLEWARE HATTI (İŞLEM SIRASI KRİTİKTİR!) ---
// Gelen her HTTP isteği bu sırayla aşağıdaki süzgeçlerden geçer.

// [Geliştirme Ortamı Kontrolü]
// Swagger'ın sadece biz kod yazarken (Development) çalışmasını, canlı ortamda (Production) gizlenmesini sağlar.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Swagger JSON dosyasını oluşturur.
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty; // API'yi başlattığında doğrudan Swagger sayfası açılır (localhost:5000/ gibi).
    });
}

// [Güvenli Bağlantı]
// Eğer HTTP üzerinden istek gelirse, otomatik olarak HTTPS'e yönlendirir.
app.UseHttpsRedirection();

// [Statik Dosyalar]
// wwwroot klasörü içindeki resim (.jpg, .png), PDF (CV gibi) veya JS dosyalarına 
// dış dünyadan (URL üzerinden) erişilmesini sağlar.
app.UseStaticFiles();

// [CORS Uygula]
// Yukarıda tanımladığımız "AllowAll" kuralını devreye sokar. Auth'dan önce gelmelidir.
app.UseCors("AllowAll");

// [Kimlik Doğrulama (Authentication)]
// Gelen isteğin içindeki Token geçerli mi? "Sen kimsin?" sorusuna yanıt arar.
app.UseAuthentication();

// [Yetkilendirme (Authorization)]
// "Senin buraya girmeye yetkin var mı?" (Admin mi, User mı?) sorusuna bakar.
app.UseAuthorization();

// [Rota Eşleme]
// Gelen isteği, Controllers klasöründeki uygun metotla (Action) eşleştirir.
app.MapControllers();

// Uygulamayı başlatır ve dinlemeye geçer.
app.Run();