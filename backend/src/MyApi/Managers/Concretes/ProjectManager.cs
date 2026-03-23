using Microsoft.EntityFrameworkCore;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.ProjectDtos;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Managers.Concretes;

public class ProjectManager : IProjectManager
{
    private readonly IProjectRepository _projectRepository;

    public ProjectManager(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }


    public async Task CreateAsync(CreateProjectDto dto)
    {
        try
        {
            await _projectRepository.AddAsync(new()
            {
                Title = dto.Title,
                CreatedDate = DateTime.UtcNow,
                Descriptions = dto.Descriptions
            .Select(x => new ProjectDescription()
            {
                Value = x,
            }).ToList()
            });
            await _projectRepository.SaveAsync();
        }
        catch (System.Exception ex)
        {
            throw new Exception($"Proje eklenirken bir hata oluştu. Mesaj: {ex.Message}");
        }
    }

    public async Task<List<ResultProjectDto>> GetAllAsync()
    {
        try
        {
            return await _projectRepository.GetAll()
                   .Include(x => x.Descriptions)
                   .Select(p => new ResultProjectDto
                   {
                       Id = p.Id,
                       CreatedDate = p.CreatedDate,
                       UpdatedDate = p.UpdatedDate,
                       Title = p.Title,
                       Descriptions = p.Descriptions
                           .Select(x => x.Value)
                           .ToList()
                   }).ToListAsync();
        }
        catch (System.Exception ex)
        {
            throw new Exception($"Proje listesi getirilirken bir hata oluştu. Mesaj: {ex.Message}");
        }
    }

    public Task<List<ResultProjectForUiDto>> GetAllForUiAsync()
    {
        try
        {
            return _projectRepository.GetAll()
                 .Include(x => x.Descriptions)
                 .Select(p => new ResultProjectForUiDto
                 {
                     Title = p.Title,
                     Descriptions = p.Descriptions
                         .Select(x => x.Value)
                         .ToList()
                 }).ToListAsync();
        }
        catch (System.Exception ex)
        {
            throw new Exception($"Proje listesi getirilirken bir hata oluştu. Mesaj: {ex.Message}");
        }
    }

    public Task<ResultProjectDto> GetByIdAsync(string id)
    {
        try
        {
            return _projectRepository.GetAll()
                .Include(x => x.Descriptions)
                .Where(x => x.Id == Guid.Parse(id))
                .Select(p => new ResultProjectDto
                {
                    Id = p.Id,
                    CreatedDate = p.CreatedDate,
                    UpdatedDate = p.UpdatedDate,
                    Title = p.Title,
                    Descriptions = p.Descriptions
                        .Select(x => x.Value)
                        .ToList()
                }).FirstOrDefaultAsync();
        }
        catch (System.Exception ex)
        {
            throw new Exception($"Proje getirilirken bir hata oluştu. Mesaj: {ex.Message}");
        }
    }

    public async Task RemoveByIdAsync(string id)
    {
        try
        {
            var project = await _projectRepository.GetByIdAsync(Guid.Parse(id));
            _projectRepository.Remove(project!);
            await _projectRepository.SaveAsync();
        }
        catch (System.Exception ex)
        {
            throw new Exception($"Proje silinirken bir hata oluştu. Mesaj: {ex.Message}");
        }
    }

    public async Task UpdateAsync(UpdateProjectDto dto)
    {
        try
        {
            var project = await _projectRepository
            .GetAll()
            .Include(x => x.Descriptions)
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (project == null)
                throw new Exception("Project not found");

            project.Title = dto.Title;
            project.UpdatedDate = DateTime.UtcNow;

            project.Descriptions.Clear();

            foreach (var item in dto.Descriptions)
            {
                project.Descriptions.Add(new ProjectDescription
                {
                    Value = item,
                    CreatedDate = DateTime.UtcNow
                });
            }

            await _projectRepository.SaveAsync();
        }
        catch (System.Exception ex)
        {
            throw new Exception($"Proje güncellenirken bir hata oluştu. Mesaj: {ex.Message}");
        }
    }
}