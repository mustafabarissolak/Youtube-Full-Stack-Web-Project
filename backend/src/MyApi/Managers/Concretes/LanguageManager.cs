using Microsoft.EntityFrameworkCore;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.LanguageDtos;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Managers.Concretes;

public class LanguageManager : ILanguageManager
{
    private readonly ILanguageRepository _repository;

    public LanguageManager(ILanguageRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ResultLanguageDto>> GetAllAsync()
    {
        try
        {
            // tracking: false -> RAM'i korur.
            return await _repository.GetAll(false)
                .Select(l => new ResultLanguageDto
                {
                    Id = l.Id,
                    Name = l.Name,
                    Description = l.Description,
                    CreatedDate = l.CreatedDate,
                    UpdatedDate = l.UpdatedDate
                }).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Dil bilgileri listelenirken bir hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task<List<ResultForUiLanguageDto>> GetAllForUiAsync()
    {
        try
        {
            return await _repository.GetAll(false)
                .Select(l => new ResultForUiLanguageDto
                {
                    Name = l.Name,
                    Description = l.Description
                }).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"UI dil listesi çekilirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task<ResultLanguageDto> GetByIdAsync(string id)
    {
        try
        {
            var language = await _repository.GetByIdAsync(Guid.Parse(id), false);
            if (language == null)
                throw new Exception($"Dil kaydı bulunamadı. Id: {id}");

            return new ResultLanguageDto
            {
                Id = language.Id,
                Name = language.Name,
                Description = language.Description,
                CreatedDate = language.CreatedDate,
                UpdatedDate = language.UpdatedDate
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Dil bilgisi görüntülenirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task CreateAsync(CreateLanguageDto dto)
    {
        try
        {
            await _repository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                CreatedDate = DateTime.UtcNow
            });
            await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Dil kaydı eklenirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task UpdateAsync(UpdateLanguageDto dto)
    {
        try
        {
            // tracking: true (Varsayılan) -> Güncelleme için nesneyi takip et
            var existing = await _repository.GetByIdAsync(dto.Id);

            if (existing == null)
                throw new Exception($"Güncellenecek dil kaydı bulunamadı. Id: {dto.Id}");

            existing.Name = dto.Name;
            existing.Description = dto.Description;
            existing.UpdatedDate = DateTime.UtcNow;

            await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Dil kaydı güncellenirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task RemoveAsync(string id)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(Guid.Parse(id), false);
            if (existing == null)
                throw new Exception($"Silinecek dil kaydı bulunamadı. Id: {id}");

            _repository.Remove(existing);
            await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Dil kaydı silinirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }
}