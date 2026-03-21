using Microsoft.EntityFrameworkCore;
using MyApi.Context;
using MyApi.Models.Entities;

namespace MyApi.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IQueryable<T> GetAll(bool tracking = true)
        => tracking ? _dbSet : _dbSet.AsNoTracking();

    public async Task<T?> GetByIdAsync(Guid id, bool tracking = true)
        => await (tracking ? _dbSet : _dbSet.AsNoTracking()).FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Remove(T entity) => _dbSet.Remove(entity);

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}