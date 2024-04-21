using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CartaoVacina.DataAccess.Repositories;

public class VacinaRepository : Repository<Vacina>, IVacinaRepository
{
    public VacinaRepository(CartaoVacinaContext context) : base(context) { }

    public async Task<IEnumerable<Vacina>> Listar()
    {
        return await _context.Vacinas.ToListAsync();
    }
}
