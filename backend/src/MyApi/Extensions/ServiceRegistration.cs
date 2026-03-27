using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MyApi.Context;
using MyApi.Managers.Abstracts;
using MyApi.Managers.Concretes;
using MyApi.Mappings;
using MyApi.Repositories;
using MyApi.Repositories.Abstracts;
using MyApi.Repositories.Concretes;
using MyApi.SmtpMailServices;

namespace MyApi.Extensions;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection")));

        services.AddAutoMapper(typeof(GeneralMapping));

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(typeof(ServiceRegistration).Assembly); // Tum validatorlari otomatik yukler

        #region Repositories 
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IAboutMeRepository, AboutMeRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<IEducationRepository, EducationRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IExperienceRepository, ExperienceRepository>();
        #endregion

        #region Managers
        services.AddScoped<IAboutMeManager, AboutMeManager>();
        services.AddScoped<IContactManager, ContactManager>();
        services.AddScoped<ISkillManager, SkillManager>();
        services.AddScoped<IEducationManager, EducationManager>();
        services.AddScoped<ILanguageManager, LanguageManager>();
        services.AddScoped<IProjectManager, ProjectManager>();
        services.AddScoped<IExperienceManager, ExperienceManager>();
        #endregion

        #region Mail Sevice
        services.Configure<SmtpSettings>(configuration.GetSection("Smtp"));
        services.AddTransient<IEmailTemplateService, EmailTemplateService>();
        services.AddScoped<IEmailSender, EmailSender>();
        #endregion

    }
}