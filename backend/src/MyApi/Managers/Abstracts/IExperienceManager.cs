using MyApi.Models.DTOs.ExperienceDtos;

namespace MyApi.Managers.Abstracts;

public interface IExperienceManager
{
    Task<List<ResultExperienceDto>> GetAllAsync();
    Task<List<ResultExperienceForUiDto>> GetAllForUiAsync();
    Task<ResultExperienceDto> GetByIdAsync(string id);

    Task CreateAsync(CreateExperienceDto dto);
    Task UpdateAsync(UpdateExperienceDto dto);
    Task RemoveByIdAsync(string id);
}
