using CartaoVacina.Core.Models.Requests.Vacina;
using CartaoVacina.Core.Models.Responses.Vacina;

namespace CartaoVacina.Core.Interfaces.Services;

public interface IVacinaService
{
    Task<ConsultaVacinaResponse[]> Listar();
    Task Criar(CriarVacinaRequest request);
}
