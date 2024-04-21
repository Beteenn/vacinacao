using CartaoVacina.Core.Entities;

namespace CartaoVacina.Core.Interfaces.Repositories;

public interface IPessoaRepository : IRepository<Pessoa>
{
    Task<IEnumerable<Pessoa>> ListarPessoas();
}
