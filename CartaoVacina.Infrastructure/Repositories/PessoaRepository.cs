using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CartaoVacina.DataAccess.Repositories;

public sealed class PessoaRepository : Repository<Pessoa>, IPessoaRepository
{
    
    public PessoaRepository(CartaoVacinaContext context) : base(context) { }

    public async Task<Pessoa> ObterPorId(long pessoaId)
    {
        return await _context.Pessoas
            .Include(p => p.CardenetaVacina)
                .ThenInclude(c => c.Vacinas)
                            .ThenInclude(c => c.Vacina)
            .FirstOrDefaultAsync(p => p.Id == pessoaId);
    }

    public async Task<IEnumerable<Pessoa>> ListarPessoas()
    {
        return await _context.Pessoas
            .Include(p => p.CardenetaVacina)
                .ThenInclude(c => c.Vacinas)
                    .ThenInclude(c => c.Vacina)
            .Include(p => p.CardenetaVacina.Vacinas)
                .ThenInclude(c => c.Doses)
            .AsNoTracking()
            .ToListAsync();
    }
}
