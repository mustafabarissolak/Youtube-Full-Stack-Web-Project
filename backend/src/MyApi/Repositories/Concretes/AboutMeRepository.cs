using MyApi.Context;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Repositories.Concretes;

public class AboutMeRepository : Repository<AboutMe>, IAboutMeRepository
{
    public AboutMeRepository(AppDbContext context) : base(context) { }
}
