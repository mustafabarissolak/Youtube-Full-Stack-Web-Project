using MyApi.Models.DTOs.SkillDtos;
using MyApi.Models.Entities;

namespace MyApi.Repositories.Abstracts;

public interface ISkillRepository
{
    Task<List<ResultSkillDto>> GetAllAsync();
    Task<List<ResultForUiSkillDto>> GetAllForUiAsync();
    Task<ResultSkillDto?> GetByIdAsync(Guid id);

    Task CreateAsync(Skill skill);
    void Update(Skill skill);
    void RemoveById(Guid id);

    Task SaveAsync();
}
