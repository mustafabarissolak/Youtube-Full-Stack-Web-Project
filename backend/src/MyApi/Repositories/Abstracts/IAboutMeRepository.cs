using MyApi.Models.DTOs.AboutMeDtos;
using MyApi.Models.Entities;

namespace MyApi.Repositories.Abstracts;

public interface IAboutMeRepository
{
    Task<List<ResultAboutMeDto>> GetAllAsync();
    Task<List<ResultForUiAboutMeDto>> GetAllForUiAsync();
    Task<ResultAboutMeDto?> GetByIdAsync(Guid id);

    Task CreateAsync(AboutMe aboutMe);
    void Update(AboutMe aboutMe);
    void Remove(AboutMe aboutMe);
    void RemoveById(Guid id);

    Task SaveAsync();
}
