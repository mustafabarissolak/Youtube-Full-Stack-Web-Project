using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.AboutMeDtos;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Managers.Concretes;

public class AboutMeManager : IAboutMeManager
{
    private readonly IAboutMeRepository _repository;
    private readonly IMapper _mapper;

    public AboutMeManager(IAboutMeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultAboutMeDto>> GetAllAsync()
    {
        var data = await _repository.GetAll(false).ToListAsync();
        return _mapper.Map<List<ResultAboutMeDto>>(data);
    }

    public async Task<List<ResultForUiAboutMeDto>> GetAllForUiAsync()
    {
        return await _repository.GetAll(false)
            .Select(x => new ResultForUiAboutMeDto
            {
                Title = x.Title,
                Description = x.Description
            }).ToListAsync();
    }

    public async Task<ResultAboutMeDto> GetByIdAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(Guid.Parse(id));

        if (entity == null)
            throw new KeyNotFoundException("Hakkimda bulunamadi.");

        return _mapper.Map<ResultAboutMeDto>(entity);
    }

    public async Task CreateAsync(CreateAboutMeDto dto)
    {
        var entity = _mapper.Map<AboutMe>(dto);
        entity.CreatedDate = DateTime.UtcNow;

        await _repository.AddAsync(entity);
        await _repository.SaveAsync();
    }

    public async Task UpdateAsync(UpdateAboutMeDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id);

        if (entity == null)
            throw new KeyNotFoundException("Hakkimda bulunamadi.");

        entity.UpdatedDate = DateTime.UtcNow;

        _mapper.Map(dto, entity);

        await _repository.SaveAsync();
    }

    public async Task RemoveByIdAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(Guid.Parse(id));

        if (entity == null)
            throw new KeyNotFoundException("Hakkimda bulunamadi.");

        _repository.Remove(entity);
        await _repository.SaveAsync();
    }
}