using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApi.Exceptions;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.EducationDtos;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Managers.Concretes;

public class EducationManager : IEducationManager
{
    private readonly IEducationRepository _repository;
    private readonly IMapper _mapper;

    public EducationManager(IEducationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultEducationDto>> GetAllAsync()
    {
        var data = await _repository.GetAll(false).ToListAsync();
        return _mapper.Map<List<ResultEducationDto>>(data);
    }

    public async Task<List<ResultForUiEducationDto>> GetAllForUiAsync()
    {
        var data = await _repository.GetAll(false)
            .Select(x => new ResultForUiEducationDto
            {
                Name = x.Name,
                Department = x.Department,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            }).ToListAsync();

        return data;
    }

    public async Task<ResultEducationDto> GetByIdAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(Guid.Parse(id), false);

        if (entity == null)
            throw new NotFoundException("Egitim bulunamadi.");

        return _mapper.Map<ResultEducationDto>(entity);
    }

    public async Task CreateAsync(CreateEducationDto dto)
    {
        var entity = _mapper.Map<Education>(dto);
        entity.CreatedDate = DateTime.UtcNow;

        await _repository.AddAsync(entity);
        await _repository.SaveAsync();
    }

    public async Task UpdateAsync(UpdateEducationDto dto)
    {
        var entity = await _repository.GetAll(true)
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (entity == null)
            throw new NotFoundException("Egitim bulunamadi.");

        entity.UpdatedDate = DateTime.UtcNow;

        _mapper.Map(dto, entity);

        await _repository.SaveAsync();
    }

    public async Task RemoveAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(Guid.Parse(id));

        if (entity == null)
            throw new NotFoundException("Egitim bulunamadi.");

        _repository.Remove(entity);
        await _repository.SaveAsync();
    }
}