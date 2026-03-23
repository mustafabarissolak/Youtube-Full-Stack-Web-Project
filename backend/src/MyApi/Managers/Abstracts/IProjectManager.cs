using MyApi.Models.DTOs.ProjectDtos;

namespace MyApi.Managers.Abstracts;

public interface IProjectManager
{
    Task<List<ResultProjectDto>> GetAllAsync();
    Task<List<ResultProjectForUiDto>> GetAllForUiAsync();
    Task<ResultProjectDto> GetByIdAsync(string id);

    Task CreateAsync(CreateProjectDto dto);
    Task UpdateAsync(UpdateProjectDto dto);
    Task RemoveByIdAsync(string id);
}
