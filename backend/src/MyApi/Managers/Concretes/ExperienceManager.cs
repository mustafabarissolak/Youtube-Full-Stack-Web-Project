using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.ExperienceDtos;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Managers.Concretes;

public class ExperienceManager : IExperienceManager
{
    private readonly IExperienceRepository _experienceRepository;
    private readonly IMapper _mapper;

    public ExperienceManager(IExperienceRepository experienceRepository, IMapper mapper)
    {
        _experienceRepository = experienceRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultExperienceDto>> GetAllAsync()
    {
        var experiences = await _experienceRepository.GetAll(tracking: false)
            .Include(x => x.Descriptions)
            .ToListAsync();

        return _mapper.Map<List<ResultExperienceDto>>(experiences);
    }

    public async Task<List<ResultExperienceForUiDto>> GetAllForUiAsync()
    {
        var experiences = await _experienceRepository.GetAll(tracking: false)
            .Include(x => x.Descriptions)
            .ToListAsync();

        return _mapper.Map<List<ResultExperienceForUiDto>>(experiences);
    }

    public async Task<ResultExperienceDto> GetByIdAsync(string id)
    {
        var experience = await _experienceRepository.GetAll(tracking: false)
             .Include(x => x.Descriptions)
             .FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        if (experience == null)
            throw new KeyNotFoundException("Deneyim bulunamadı.");

        return _mapper.Map<ResultExperienceDto>(experience);
    }

    public async Task CreateAsync(CreateExperienceDto dto)
    {
        var experience = _mapper.Map<Experience>(dto);

        experience.CreatedDate = DateTime.UtcNow;

        await _experienceRepository.AddAsync(experience);
        await _experienceRepository.SaveAsync();
    }

    public async Task UpdateAsync(UpdateExperienceDto dto)
    {
        var experience = await _experienceRepository.GetAll()
                .Include(x => x.Descriptions)
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

        _mapper.Map(dto, experience);
        if (experience == null)
            throw new KeyNotFoundException("Deneyim bulunamadı.");
        experience.UpdatedDate = DateTime.UtcNow;
        experience.Descriptions.Clear();
        foreach (var item in dto.Descriptions)
        {
            experience.Descriptions.Add(new ExperienceDescription
            {
                Value = item,
                CreatedDate = DateTime.UtcNow
            });
        }

        _experienceRepository.Update(experience);
        await _experienceRepository.SaveAsync();
    }

    public async Task RemoveByIdAsync(string id)
    {
        var experience = await _experienceRepository.GetByIdAsync(Guid.Parse(id));
        if (experience == null)
            throw new KeyNotFoundException("Deneyim bulunamadı.");
        _experienceRepository.Remove(experience);
        await _experienceRepository.SaveAsync();
    }
}
