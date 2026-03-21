using Microsoft.EntityFrameworkCore;
using MyApi.Context;
using MyApi.Models.DTOs.SkillDtos;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Repositories.Concretes;

public class SkillRepository : ISkillRepository
{
    private readonly AppDbContext _context;

    public SkillRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Skill skill)
    {
        skill.CreatedDate = DateTime.UtcNow;
        await _context.Skills.AddAsync(skill);
    }

    // public void RemoveById(Guid id)
    //      => _context.Skills.Where(s => s.Id == id).ExecuteDelete();

    public void RemoveById(Guid id)
    {
        Skill skill = _context.Skills.FirstOrDefault(s => s.Id == id)!;
        if (skill is not null)
            _context.Skills.Remove(skill);
    }

    public void Update(Skill skill)
    {
        skill.UpdatedDate = DateTime.UtcNow;
        _context.Skills.Update(skill);
    }

    public async Task<List<ResultSkillDto>> GetAllAsync()
        => await _context.Skills.Select(s => new ResultSkillDto
        {
            Id = s.Id,
            CreatedDate = s.CreatedDate,
            UpdatedDate = s.UpdatedDate,
            Name = s.Name,
            Value = s.Value
        }).ToListAsync();

    public async Task<List<ResultForUiSkillDto>> GetAllForUiAsync()
        => await _context.Skills.Select(s => new ResultForUiSkillDto
        {
            Name = s.Name,
            Value = s.Value
        }).AsNoTracking().ToListAsync();

    public async Task<ResultSkillDto?> GetByIdAsync(Guid id)
    {
        return await _context.Skills.Where(s => s.Id == id)
                 .Select(s => new ResultSkillDto
                 {
                     Id = s.Id,
                     Name = s.Name,
                     Value = s.Value,
                     CreatedDate = s.CreatedDate,
                     UpdatedDate = s.UpdatedDate,
                 }).FirstOrDefaultAsync();
    }

    public async Task SaveAsync()
        => await _context.SaveChangesAsync();
}
