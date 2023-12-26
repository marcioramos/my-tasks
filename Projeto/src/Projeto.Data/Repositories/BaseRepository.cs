using Microsoft.EntityFrameworkCore;
using Projeto.Data.Context;
using Projeto.Domain.Entities;
using Projeto.Domain.Interfaces;

namespace Projeto.Data.Repositories;

public class BaseRepository<T>(ContextoBd contextoBd) : IBaseRepository<T> where T : BaseEntity
{
    protected readonly ContextoBd _contextoBd = contextoBd;

    public void Create(T entity)
    {
        entity.DateCreated = DateTimeOffset.UtcNow;
        _contextoBd.Add(entity);
    }

    public void Delete(T entity)
    {
        entity.DateDeleted = DateTimeOffset.UtcNow;
        _contextoBd.Remove(entity);
    }

    public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _contextoBd.Set<T>().FirstOrDefaultAsync(n => n.Id == id, cancellationToken);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _contextoBd.Set<T>().ToListAsync(cancellationToken);
    }

    public void Update(T entity)
    {
        entity.DateUpdated = DateTimeOffset.UtcNow;
        _contextoBd.Update(entity);
    }
}
