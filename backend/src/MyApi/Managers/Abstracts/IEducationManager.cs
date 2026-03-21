using MyApi.Models.DTOs.EducationDtos;

namespace MyApi.Managers.Abstracts;

public interface IEducationManager
{
    Task<List<ResultEducationDto>> GetAllAsync();
    Task<List<ResultForUiEducationDto>> GetAllForUiAsync();
    Task<ResultEducationDto> GetByIdAsync(string id);

    Task CreateAsync(CreateEducationDto dto);
    Task UpdateAsync(UpdateEducationDto dto);
    Task RemoveAsync(string id);
}
