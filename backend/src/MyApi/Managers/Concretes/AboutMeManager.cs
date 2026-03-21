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
            await _repository.CreateAsync(new()
            {
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
            return await _repository.GetAllAsync();

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
            return await _repository.GetAllForUiAsync();
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
            var dto = await _repository.GetByIdAsync(Guid.Parse(id));
            if (dto == null)
                throw new Exception($"Hakkimda bilgisi bulunamadi. Id: {id}");
            return dto;
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
            _repository.RemoveById(Guid.Parse(id));
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
            _repository.Update(new()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                UpdatedDate = DateTime.UtcNow
            });
            await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Hakkidma guncellenirken bir hata olustu. Hata mesaji: {ex.Message}", ex);
        }
    }
}
