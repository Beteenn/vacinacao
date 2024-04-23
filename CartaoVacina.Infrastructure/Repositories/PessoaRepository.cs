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
            .Include(p => p.CadernetaVacina)
                .ThenInclude(c => c.Vacinacoes)
                    .ThenInclude(v => v.Vacina)
            .FirstOrDefaultAsync(p => p.Id == pessoaId);
    }

    public async Task<IEnumerable<Pessoa>> ListarPessoas()
    {
        return await _context.Pessoas
            .Include(p => p.CadernetaVacina)
            .AsNoTracking()
            .ToListAsync();
    }
}
