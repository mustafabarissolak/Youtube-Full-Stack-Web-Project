using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.LanguageDtos;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Managers.Concretes;

public class LanguageManager : ILanguageManager
{
    private readonly ILanguageRepository _repository;
    private readonly IMapper _mapper;

    public LanguageManager(ILanguageRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultLanguageDto>> GetAllAsync()
    {
        var data = await _repository.GetAll(false).ToListAsync();
        return _mapper.Map<List<ResultLanguageDto>>(data);
    }

    public async Task<List<ResultForUiLanguageDto>> GetAllForUiAsync()
    {
        var data = await _repository.GetAll(false)
            .Select(x => new ResultForUiLanguageDto
            {
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();

        return data;
    }

    public async Task<ResultLanguageDto> GetByIdAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(Guid.Parse(id), false);

        if (entity == null)
            throw new KeyNotFoundException("Dil bulunamadi.");

        return _mapper.Map<ResultLanguageDto>(entity);
    }

    public async Task CreateAsync(CreateLanguageDto dto)
    {
        var entity = _mapper.Map<Language>(dto);
        entity.CreatedDate = DateTime.UtcNow;

        await _repository.AddAsync(entity);
        await _repository.SaveAsync();
    }

    public async Task UpdateAsync(UpdateLanguageDto dto)
    {
        var entity = await _repository.GetAll(true)
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (entity == null)
            throw new KeyNotFoundException("Dil bulunamadi.");

        entity.UpdatedDate = DateTime.UtcNow;

        _mapper.Map(dto, entity);

        await _repository.SaveAsync();
    }

    public async Task RemoveAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(Guid.Parse(id));

        if (entity == null)
            throw new KeyNotFoundException("Dil bulunamadi.");

        _repository.Remove(entity);
        await _repository.SaveAsync();
    }
}