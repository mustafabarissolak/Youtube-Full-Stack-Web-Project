using Microsoft.EntityFrameworkCore;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.SkillDtos;
using MyApi.Repositories.Abstracts;

namespace MyApi.Managers.Concretes;

public class SkillManager : ISkillManager
{
    private readonly ISkillRepository _repository;

    public SkillManager(ISkillRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ResultSkillDto>> GetAllAsync()
    {
        try
        {
            return await _repository.GetAll(false)
                .Select(s => new ResultSkillDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Value = s.Value,
                    CreatedDate = s.CreatedDate,
                    UpdatedDate = s.UpdatedDate
                }).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Yetenekler listelenirken bir hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task<List<ResultForUiSkillDto>> GetAllForUiAsync()
    {
        try
        {
            return await _repository.GetAll(false)
                .Select(s => new ResultForUiSkillDto
                {
                    Name = s.Name,
                    Value = s.Value
                }).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"UI yetenek listesi çekilirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task<ResultSkillDto> GetByIdAsync(string id)
    {
        try
        {
            var skill = await _repository.GetByIdAsync(Guid.Parse(id), false);
            if (skill == null)
                throw new Exception($"Yetenek bulunamadı. Id: {id}");

            return new ResultSkillDto
            {
                Id = skill.Id,
                Name = skill.Name,
                Value = skill.Value,
                CreatedDate = skill.CreatedDate,
                UpdatedDate = skill.UpdatedDate
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Yetenek görüntülenirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task CreateAsync(CreateSkillDto dto)
    {
        try
        {
            await _repository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Value = dto.Value,
                CreatedDate = DateTime.UtcNow
            });
            await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Yetenek eklenirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task UpdateAsync(UpdateSkillDto dto)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(dto.Id);

            if (existing == null)
                throw new Exception($"Güncellenecek yetenek bulunamadı. Id: {dto.Id}");

            existing.Name = dto.Name;
            existing.Value = dto.Value;
            existing.UpdatedDate = DateTime.UtcNow;

            await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Yetenek güncellenirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task RemoveAsync(string id)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(Guid.Parse(id), false);
            if (existing == null)
                throw new Exception($"Silinecek yetenek bulunamadı. Id: {id}");
            _repository.Remove(existing);
            await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Yetenek silinirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }
}
