using Microsoft.EntityFrameworkCore;
using MyApi.Context;
using MyApi.Models.DTOs.AboutMeDtos;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Repositories.Concretes;

public class AboutMeRepository : IAboutMeRepository
{
    private readonly AppDbContext _context;

    public AboutMeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(AboutMe aboutMe)
        => await _context.AboutsMe.AddAsync(aboutMe);

    public void Update(AboutMe aboutMe)
        => _context.AboutsMe.Update(aboutMe);

    public void RemoveById(Guid id)
        => _context.AboutsMe.Remove(new AboutMe { Id = id });

    public void Remove(AboutMe aboutMe)
        => _context.AboutsMe.Remove(aboutMe);

    public async Task<List<ResultAboutMeDto>> GetAllAsync()
        => await _context.AboutsMe.Select(a => new ResultAboutMeDto
        {
            Id = a.Id,
            Title = a.Title,
            Description = a.Description,
            CreatedDate = a.CreatedDate,
            UpdatedDate = a.UpdatedDate,
            DeletedDate = a.DeletedDate
        }).ToListAsync();

    public async Task<List<ResultForUiAboutMeDto>> GetAllForUiAsync()
        => await _context.AboutsMe.Select(a => new ResultForUiAboutMeDto
        {
            Title = a.Title,
            Description = a.Description
        }).ToListAsync();

    public Task<ResultAboutMeDto?> GetByIdAsync(Guid id)
        => _context.AboutsMe.Where(a => a.Id == id).Select(a => new ResultAboutMeDto
        {
            Id = a.Id,
            Title = a.Title,
            Description = a.Description,
            CreatedDate = a.CreatedDate,
            UpdatedDate = a.UpdatedDate,
            DeletedDate = a.DeletedDate
        }).FirstOrDefaultAsync();

    public Task SaveAsync()
        => _context.SaveChangesAsync();

}
