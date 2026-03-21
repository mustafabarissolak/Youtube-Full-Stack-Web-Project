using MyApi.Models.Entities;

namespace MyApi.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true);
    Task<T?> GetByIdAsync(Guid id, bool tracking = true);
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);

    Task SaveAsync();
}
