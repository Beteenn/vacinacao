using CartaoVacina.Core.Entities;

namespace CartaoVacina.Core.Interfaces.Repositories;

public interface IVacinaRepository : IRepository<Vacina>
{
    Task<IEnumerable<Vacina>> Listar();
    Task<Vacina> ObterPorId(long vacinaId);
}
