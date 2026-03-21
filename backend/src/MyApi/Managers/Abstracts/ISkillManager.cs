using MyApi.Models.DTOs.SkillDtos;

namespace MyApi.Managers.Abstracts;

public interface ISkillManager
{
    // Okuma İşlemleri (UI ve Liste ekranları için)
    Task<List<ResultSkillDto>> GetAllAsync();
    Task<List<ResultForUiSkillDto>> GetAllForUiAsync();
    Task<ResultSkillDto> GetByIdAsync(string id);

    // Yazma ve Güncelleme İşlemleri
    Task CreateAsync(CreateSkillDto dto);
    Task UpdateAsync(UpdateSkillDto dto);
    Task RemoveAsync(string id);
}
