using MyApi.Context;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Repositories.Concretes;

public class ExperienceRepository : Repository<Experience>, IExperienceRepository
{
    public ExperienceRepository(AppDbContext context) : base(context) { }
}
