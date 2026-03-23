using MyApi.Models.DTOs.SkillDtos;

namespace MyApi.Managers.Abstracts;

public interface ISkillManager
{
    Task<List<ResultSkillDto>> GetAllAsync();
    Task<List<ResultForUiSkillDto>> GetAllForUiAsync();
    Task<ResultSkillDto> GetByIdAsync(string id);

    Task CreateAsync(CreateSkillDto dto);
    Task UpdateAsync(UpdateSkillDto dto);
    Task RemoveAsync(string id);
}
