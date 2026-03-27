using Microsoft.EntityFrameworkCore;
using MyApi.Models.Entities;

namespace MyApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<AboutMe> AboutsMe => Set<AboutMe>();
    public DbSet<Education> Educations => Set<Education>();
    public DbSet<Experience> Experiences => Set<Experience>();
    public DbSet<ExperienceDescription> ExperienceDescriptions => Set<ExperienceDescription>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectDescription> ProjectDescriptions => Set<ProjectDescription>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Contact> Contacts => Set<Contact>();
}