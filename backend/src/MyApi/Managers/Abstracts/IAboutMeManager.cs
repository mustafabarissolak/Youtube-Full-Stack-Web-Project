using MyApi.Models.DTOs.AboutMeDtos;

namespace MyApi.Managers.Abstracts;

public interface IAboutMeManager
{
    Task<List<ResultAboutMeDto>> GetAllAsync();
    Task<List<ResultForUiAboutMeDto>> GetAllForUiAsync();
    Task<ResultAboutMeDto?> GetByIdAsync(string id);

    Task CreateAsync(CreateAboutMeDto dto);
    Task UpdateAsync(UpdateAboutMeDto dto);
    Task RemoveByIdAsync(string id);
}
