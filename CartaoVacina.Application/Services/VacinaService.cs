﻿using CartaoVacina.Core.Entities;
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

    public async Task<Result<ConsultaVacinaSimplificadaResponse[]>> Listar()
    {
        var vacinas = await _vacinaRepository.Listar();

        if (!vacinas.Any())
            return Result<ConsultaVacinaSimplificadaResponse[]>.Success(null);

        var vacinasReponse = vacinas
            .Select(x => new ConsultaVacinaSimplificadaResponse(x.Id, x.Nome, x.QuantidadeDoses, x.QuantidadeReforcos))
            .ToArray();

        return Result<ConsultaVacinaSimplificadaResponse[]>.Success(vacinasReponse);
    }

    public async Task<Result> Criar(CriarVacinaRequest request)
    {
        var vacina = Vacina.Criar(request.Nome, request.QuantidadeDoses, request.QuantidadeReforcos);

        await _vacinaRepository.AddAsync(vacina);
        await _vacinaRepository.UnityOfWork.SaveChangesAsync();

        return Result.Success;
    }

    public async Task<Result> AplicarDose(AplicarNovaDoseRequest request)
    {
        var pessoa = await _pessoaRepository.ObterPorId(request.PessoaId);

        if (pessoa == null)
            return Result.Fail("Pessoa não encontrada.");

        var vacina = await _vacinaRepository.ObterPorId(request.VacinaId);

        if (vacina == null)
            return Result.Fail("Vacina não encontrada.");

        var caderneta = pessoa.CadernetaVacina;

        var doseAplicadaResult = caderneta.AdicionarVacinacao(vacina, request.NumeroDose, request.DataAplicacao, request.Tipo);

        if (!doseAplicadaResult)
            return doseAplicadaResult;

        await _pessoaRepository.UpdateAsync(pessoa);
        await _pessoaRepository.UnityOfWork.SaveChangesAsync();

        return doseAplicadaResult;
    }
}
