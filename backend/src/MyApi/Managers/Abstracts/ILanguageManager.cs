using MyApi.Models.DTOs.LanguageDtos;

namespace MyApi.Managers.Abstracts;

public interface ILanguageManager
{
    Task<List<ResultLanguageDto>> GetAllAsync();
    Task<List<ResultForUiLanguageDto>> GetAllForUiAsync();
    Task<ResultLanguageDto> GetByIdAsync(string id);

    Task CreateAsync(CreateLanguageDto dto);
    Task UpdateAsync(UpdateLanguageDto dto);
    Task RemoveAsync(string id);
}