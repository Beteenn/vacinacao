using CartaoVacina.Core.Entities;

namespace CartaoVacina.Core.Interfaces.Repositories;

public interface IPessoaRepository : IRepository<Pessoa>
{
    Task<Pessoa> ObterPorId(long pessoaId);
    Task<IEnumerable<Pessoa>> ListarPessoas();
}
