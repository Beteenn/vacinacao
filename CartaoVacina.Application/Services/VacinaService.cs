using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Vacina;
using CartaoVacina.Core.Models.Responses.Vacina;

namespace CartaoVacina.Application.Services;

public class VacinaService : IVacinaService
{
    private readonly IVacinaRepository _vacinaRepository;

    public VacinaService(IVacinaRepository vacinaRepository)
    {
        _vacinaRepository = vacinaRepository ?? throw new ArgumentNullException();
    }

    public async Task<ConsultaVacinaResponse[]> Listar()
    {
        var vacinas = await _vacinaRepository.Listar();

        return vacinas.Select(x => new ConsultaVacinaResponse(x.Id, x.Nome, x.QuantidadeDoses, x.QuantidadeReforcos)).ToArray();
    }

    public async Task Criar(CriarVacinaRequest request)
    {
        var vacina = Vacina.Criar(request.Nome, request.QuantidadeDoses, request.QuantidadeReforcos);

        await _vacinaRepository.AddAsync(vacina);
        await _vacinaRepository.UnityOfWork.SaveChangesAsync();
    }
}
