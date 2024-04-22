using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Vacina;
using CartaoVacina.Core.Models.Responses.Vacina;
using CartaoVacina.Core.Results;

namespace CartaoVacina.Application.Services;

public class VacinaService : IVacinaService
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IVacinaRepository _vacinaRepository;

    public VacinaService(IVacinaRepository vacinaRepository, IPessoaRepository pessoaRepository)
    {
        _vacinaRepository = vacinaRepository ?? throw new ArgumentNullException();
        _pessoaRepository = pessoaRepository ?? throw new ArgumentNullException();
    }

    public async Task<ConsultaVacinaResponse[]> Listar()
    {
        var vacinas = await _vacinaRepository.Listar();

        return vacinas
            .Select(x => new ConsultaVacinaResponse(x.Id, x.Nome, x.QuantidadeDoses, x.QuantidadeReforcos))
            .ToArray();
    }

    public async Task Criar(CriarVacinaRequest request)
    {
        var vacina = Vacina.Criar(request.Nome, request.QuantidadeDoses, request.QuantidadeReforcos);

        await _vacinaRepository.AddAsync(vacina);
        await _vacinaRepository.UnityOfWork.SaveChangesAsync();
    }

    public async Task<Result> AplicarDose(AplicarNovaDoseRequest request)
    {
        var pessoa = await _pessoaRepository.ObterPorId(request.PessoaId);

        if (pessoa == null)
            return Result.Fail("Pessoa não encontrada.");

        var carteneta = pessoa.CardenetaVacina;

        var doseAplicadaResult = carteneta.AplicarDose(request.VacinaId, request.NumeroDose, request.DataAplicacao);

        if (!doseAplicadaResult)
            return doseAplicadaResult;

        await _pessoaRepository.UpdateAsync(pessoa);
        await _pessoaRepository.UnityOfWork.SaveChangesAsync();

        return doseAplicada;
    }
}
