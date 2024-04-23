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
        return await _context.Vacinas.AsNoTracking().ToListAsync();
    }

    public async Task<Vacina> ObterPorId(long vacinaId)
    {
        return await _context.Vacinas.FirstOrDefaultAsync(x => x.Id == vacinaId);
    }
}
