using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.DataAccess.Persistence;

namespace CartaoVacina.DataAccess.Repositories;

public sealed class PessoaRepository : Repository<Pessoa>, IPessoaRepository
{
    
    public PessoaRepository(CartaoVacinaContext context) : base(context) { }
}
