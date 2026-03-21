using MyApi.Context;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Repositories.Concretes;

public class EducationRepository : Repository<Education>, IEducationRepository
{
    public EducationRepository(AppDbContext context) : base(context) { }
}
