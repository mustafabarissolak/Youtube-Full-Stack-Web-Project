using MyApi.Context;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Repositories.Concretes;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    public ProjectRepository(AppDbContext context) : base(context) { }
}
