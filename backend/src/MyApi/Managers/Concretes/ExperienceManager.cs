using Microsoft.EntityFrameworkCore;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.ExperienceDtos;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Managers.Concretes;

public class ExperienceManager : IExperienceManager
{
    private readonly IExperienceRepository _experienceRepository;

    public ExperienceManager(IExperienceRepository experienceRepository)
    {
        _experienceRepository = experienceRepository;
    }

    public async Task CreateAsync(CreateExperienceDto dto)
    {
        try
        {
            await _experienceRepository.AddAsync(new()
            {
                Title = dto.Title,
                CreatedDate = DateTime.UtcNow,
                Descriptions = dto.Descriptions
                 .Select(x => new ExperienceDescription()
                 {
                     Value = x,
                 }).ToList()
            });
            await _experienceRepository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Deneyim bilgileri eklenirken bir hata oluştu. Mesaj: {ex.Message}");
        }
    }

    public async Task<List<ResultExperienceDto>> GetAllAsync()
    {
        try
        {
            return await _experienceRepository.GetAll()
                .Include(x => x.Descriptions)
                .Select(e => new ResultExperienceDto
                {
                    Id = e.Id,
                    CreatedDate = e.CreatedDate,
                    UpdatedDate = e.UpdatedDate,
                    Title = e.Title,
                    Descriptions = e.Descriptions
                        .Select(x => x.Value)
                        .ToList()
                }).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Deneyim bilgileri listelenirken bir hata oluştu. {ex.Message}");
        }
    }

    public Task<List<ResultExperienceForUiDto>> GetAllForUiAsync()
    {
        try
        {
            return _experienceRepository.GetAll()
                 .Include(x => x.Descriptions)
                 .Select(e => new ResultExperienceForUiDto
                 {
                     Title = e.Title,
                     Descriptions = e.Descriptions
                         .Select(x => x.Value)
                         .ToList()
                 }).ToListAsync();
        }
        catch (System.Exception ex)
        {
            throw new Exception($"Deneyim bilgileri listelenirken bir hata oluştu. {ex.Message}");
        }
    }

    public async Task<ResultExperienceDto> GetByIdAsync(string id)
    {
        try
        {
            return await _experienceRepository.GetAll()
                .Where(x => x.Id == Guid.Parse(id))
                .Include(x => x.Descriptions)
                .Select(e => new ResultExperienceDto
                {
                    Id = e.Id,
                    CreatedDate = e.CreatedDate,
                    UpdatedDate = e.UpdatedDate,
                    Title = e.Title,
                    Descriptions = e.Descriptions
                         .Select(x => x.Value)
                         .ToList()
                }).FirstOrDefaultAsync();
        }
        catch (System.Exception ex)
        {
            throw new Exception($"Deneyim bilgisi getirilirken bir hata oluştu. {ex.Message}");
        }
    }

    public async Task RemoveByIdAsync(string id)
    {
        try
        {
            var experience = await _experienceRepository.GetByIdAsync(Guid.Parse(id));
            if (experience is null)
                throw new Exception("Deneyim bilgisi bulunamadı.");
            _experienceRepository.Remove(experience);
            await _experienceRepository.SaveAsync();
        }
        catch (System.Exception ex)
        {
            throw new Exception($"Deneyim bilgisi silinirken bir hata oluştu. {ex.Message}");
        }
    }

    public async Task UpdateAsync(UpdateExperienceDto dto)
    {
        try
        {
            var experience = await _experienceRepository.GetAll().Include(e => e.Descriptions).FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (experience is null)
                throw new Exception("Deneyim bilgisi bulunamadı.");

            experience.Title = dto.Title;
            experience.UpdatedDate = DateTime.UtcNow;

            experience.Descriptions.Clear();
            foreach (var description in dto.Descriptions)
            {
                experience.Descriptions.Add(new ExperienceDescription
                {
                    Value = description,
                    CreatedDate = DateTime.UtcNow
                });
            }

            await _experienceRepository.SaveAsync();
        }
        catch (System.Exception ex)
        {
            throw new Exception($"Deneyim bilgisi güncellenirken bir hata oluştu. {ex.Message}");
        }
    }

}
