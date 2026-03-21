using Microsoft.EntityFrameworkCore;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.EducationDtos;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Managers.Concretes;

public class EducationManager : IEducationManager
{
    private readonly IEducationRepository _repository;

    public EducationManager(IEducationRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ResultEducationDto>> GetAllAsync()
    {
        try
        {
            // tracking: false -> Hafıza (RAM) tasarrufu sağlar.
            return await _repository.GetAll(false)
                .Select(e => new ResultEducationDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Department = e.Department,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    CreatedDate = e.CreatedDate,
                    UpdatedDate = e.UpdatedDate
                }).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Eğitim bilgileri listelenirken bir hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task<List<ResultForUiEducationDto>> GetAllForUiAsync()
    {
        try
        {
            return await _repository.GetAll(false)
                .Select(e => new ResultForUiEducationDto
                {
                    Name = e.Name,
                    Department = e.Department,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                }).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"UI eğitim listesi çekilirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task<ResultEducationDto> GetByIdAsync(string id)
    {
        try
        {
            var education = await _repository.GetByIdAsync(Guid.Parse(id), false);
            if (education == null)
                throw new Exception($"Eğitim kaydı bulunamadı. Id: {id}");

            return new ResultEducationDto
            {
                Id = education.Id,
                Name = education.Name,
                Department = education.Department,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                CreatedDate = education.CreatedDate,
                UpdatedDate = education.UpdatedDate
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Eğitim bilgisi görüntülenirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task CreateAsync(CreateEducationDto dto)
    {
        try
        {
            await _repository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Department = dto.Department,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                CreatedDate = DateTime.UtcNow
            });
            await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Eğitim kaydı eklenirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task UpdateAsync(UpdateEducationDto dto)
    {
        try
        {
            // Güncelleme için nesneyi track (takip) ediyoruz.
            var existing = await _repository.GetByIdAsync(dto.Id);

            if (existing == null)
                throw new Exception($"Güncellenecek eğitim kaydı bulunamadı. Id: {dto.Id}");

            existing.Name = dto.Name;
            existing.Department = dto.Department;
            existing.StartDate = dto.StartDate;
            existing.EndDate = dto.EndDate;
            existing.UpdatedDate = DateTime.UtcNow;

            await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Eğitim kaydı güncellenirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }

    public async Task RemoveAsync(string id)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(Guid.Parse(id), false);
            if (existing == null)
                throw new Exception($"Silinecek eğitim kaydı bulunamadı. Id: {id}");

            _repository.Remove(existing);
            await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Eğitim kaydı silinirken hata oluştu. Mesaj: {ex.Message}", ex);
        }
    }
}