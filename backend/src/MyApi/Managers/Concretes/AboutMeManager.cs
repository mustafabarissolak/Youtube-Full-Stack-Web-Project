using Microsoft.EntityFrameworkCore;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.AboutMeDtos;
using MyApi.Repositories.Abstracts;

namespace MyApi.Managers.Concretes;

public class AboutMeManager : IAboutMeManager
{
    private readonly IAboutMeRepository _repository;

    public AboutMeManager(IAboutMeRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(CreateAboutMeDto dto)
    {
        try
        {
            await _repository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                Title = dto.Title,
                Description = dto.Description
            });
            await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Hakkimda eklenirken bir hata olustu. Hata mesaji: {ex.Message}", ex);
        }
    }

    public async Task<List<ResultAboutMeDto>> GetAllAsync()
    {
        try
        {
            var abouts = _repository.GetAll();
            return await abouts.Select(a => new ResultAboutMeDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate
            }).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Hakkimda listelenirken bir hata olustu. Hata mesaji: {ex.Message}", ex);
        }
    }

    public async Task<List<ResultForUiAboutMeDto>> GetAllForUiAsync()
    {
        try
        {
            return await _repository.GetAll(tracking: false).Select(a => new ResultForUiAboutMeDto
            {
                Title = a.Title,
                Description = a.Description
            }).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Hakkimda listelenirken bir hata olustu. Hata mesaji: {ex.Message}", ex);
        }
    }

    public async Task<ResultAboutMeDto?> GetByIdAsync(string id)
    {
        try
        {
            var about = await _repository.GetByIdAsync(Guid.Parse(id));
            if (about == null)
                throw new Exception($"Hakkimda bilgisi bulunamadi. Id: {id}");
            return new ResultAboutMeDto
            {
                Id = about.Id,
                Title = about.Title,
                Description = about.Description,
                CreatedDate = about.CreatedDate,
                UpdatedDate = about.UpdatedDate
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Hakkimda goruntulenirken bir hata olustu. Hata mesaji: {ex.Message}", ex);
        }
    }

    public async Task RemoveByIdAsync(string id)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(Guid.Parse(id));
            if (existing == null)
                throw new Exception($"Silinecek Hakkimda bilgisi bulunamadi. Id: {id}");
            _repository.Remove(existing);
            await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Hakkidma silinirken bir hata olustu. Hata mesaji: {ex.Message}", ex);
        }
    }

    public async Task UpdateAsync(UpdateAboutMeDto dto)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(dto.Id);

            if (existing == null)
                throw new Exception($"Hakkimda bilgisi bulunamadi. Id: {dto.Id}");

            existing.Title = dto.Title;
            existing.Description = dto.Description;
            existing.UpdatedDate = DateTime.UtcNow;

            await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Hakkidma guncellenirken bir hata olustu. Hata mesaji: {ex.Message}", ex);
        }
    }
}
