using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.ProjectDtos;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Managers.Concretes;

public class ProjectManager : IProjectManager
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectManager(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultProjectDto>> GetAllAsync()
    {
        var projects = await _projectRepository.GetAll(tracking: false)
            .Include(x => x.Descriptions)
            .ToListAsync();

        return _mapper.Map<List<ResultProjectDto>>(projects);
    }

    public async Task<List<ResultProjectForUiDto>> GetAllForUiAsync()
    {
        var projects = await _projectRepository.GetAll(tracking: false)
            .Include(x => x.Descriptions)
            .ToListAsync();

        return _mapper.Map<List<ResultProjectForUiDto>>(projects);
    }

    public async Task<ResultProjectDto> GetByIdAsync(string id)
    {
        var project = await _projectRepository.GetAll(tracking: false)
            .Include(x => x.Descriptions)
            .FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        if (project == null)
            throw new KeyNotFoundException("Proje bulunamadı.");
        return _mapper.Map<ResultProjectDto>(project);
    }

    public async Task CreateAsync(CreateProjectDto dto)
    {
        var project = _mapper.Map<Project>(dto);

        project.CreatedDate = DateTime.UtcNow;

        await _projectRepository.AddAsync(project);
        await _projectRepository.SaveAsync();
    }

    public async Task UpdateAsync(UpdateProjectDto dto)
    {
        var project = await _projectRepository.GetAll()
                .Include(x => x.Descriptions)
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (project == null)
            throw new KeyNotFoundException("Proje bulunamadı.");

        _mapper.Map(dto, project);
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

    public async Task RemoveByIdAsync(string id)
    {
        var project = await _projectRepository.GetByIdAsync(Guid.Parse(id));
        if (project == null)
            throw new KeyNotFoundException("Proje bulunamadı.");
        _projectRepository.Remove(project);
        await _projectRepository.SaveAsync();
    }
}