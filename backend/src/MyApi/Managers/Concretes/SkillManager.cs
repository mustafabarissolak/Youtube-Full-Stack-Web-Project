using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.SkillDtos;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Managers.Concretes;

public class SkillManager : ISkillManager
{
    private readonly ISkillRepository _repository;
    private readonly IMapper _mapper;

    public SkillManager(ISkillRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultSkillDto>> GetAllAsync()
    {
        var skill = await _repository.GetAll(false).ToListAsync();
        return _mapper.Map<List<ResultSkillDto>>(skill);
    }

    public async Task<List<ResultForUiSkillDto>> GetAllForUiAsync()
    {
        var skill = await _repository.GetAll(false)
                    .Select(s => new ResultForUiSkillDto()
                    {
                        Name = s.Name,
                        Value = s.Value,
                    }).ToListAsync();
        return _mapper.Map<List<ResultForUiSkillDto>>(skill);
    }

    public async Task<ResultSkillDto> GetByIdAsync(string id)
    {
        var skill = await _repository.GetByIdAsync(Guid.Parse(id), false);
        if (skill == null)
            throw new KeyNotFoundException("Beceri bulunamadı.");
        return _mapper.Map<ResultSkillDto>(skill);
    }

    public async Task CreateAsync(CreateSkillDto dto)
    {
        var skill = _mapper.Map<Skill>(dto);

        skill.CreatedDate = DateTime.UtcNow;

        await _repository.AddAsync(skill);
        await _repository.SaveAsync();
    }

    public async Task UpdateAsync(UpdateSkillDto dto)
    {
        var skill = await _repository.GetAll(true).FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (skill == null)
            throw new KeyNotFoundException("Beceri bulunamadı.");
        skill.UpdatedDate = DateTime.UtcNow;
        _mapper.Map(dto, skill);
        await _repository.SaveAsync();
    }

    public async Task RemoveAsync(string id)
    {
        var skill = await _repository.GetByIdAsync(Guid.Parse(id));
        if (skill == null)
            throw new KeyNotFoundException("Beceri bulunamadı.");
        _repository.Remove(skill);
        await _repository.SaveAsync();
    }
}
