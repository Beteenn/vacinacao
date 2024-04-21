using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.DataAccess.Persistence;

namespace CartaoVacina.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected CartaoVacinaContext _context;

    public Repository(CartaoVacinaContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entidade)
    {
        await _context.AddAsync(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entidade)
    {
        await Task.Run(() => _context.Update(entidade));
    }

    public async Task DeleteAsync(T entidade)
    {
        await Task.Run(() => _context.Remove(entidade));
    }
}
