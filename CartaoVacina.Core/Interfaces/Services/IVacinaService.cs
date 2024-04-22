using CartaoVacina.Core.Models.Requests.Vacina;
using CartaoVacina.Core.Models.Responses.Vacina;
using CartaoVacina.Core.Results;

namespace CartaoVacina.Core.Interfaces.Services;

public interface IVacinaService
{
    Task<Result<ConsultaVacinaResponse[]>> Listar();
    Task<Result> Criar(CriarVacinaRequest request);
    Task<Result> AplicarDose(AplicarNovaDoseRequest request);
}
