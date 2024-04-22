using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Pessoa;
using CartaoVacina.Core.Models.Responses.Pessoa;
using CartaoVacina.Core.Models.Responses.Vacina;
using CartaoVacina.Core.Results;

namespace CartaoVacina.Application.Services;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IVacinaRepository _vacinaRepository;

    public PessoaService(IPessoaRepository pessoaRepository, IVacinaRepository vacinaRepository)
    {
        _pessoaRepository = pessoaRepository ?? throw new ArgumentNullException();
        _vacinaRepository = vacinaRepository ?? throw new ArgumentNullException();
    }

    public async Task<Result<ConsultarPessoaSimplificadaResponse[]>> ListarPessoas()
    {
        var pessoas = await _pessoaRepository.ListarPessoas();

        if (!pessoas.Any())
            return Result < ConsultarPessoaSimplificadaResponse[] >.Success(null);

        var pessoasResponse = pessoas.Select(pessoa => new ConsultarPessoaSimplificadaResponse(pessoa.Id, pessoa.Nome)).ToArray();

        return Result<ConsultarPessoaSimplificadaResponse[]>.Success(pessoasResponse);
    }

    public async Task<Result> CriarPessoa(CriarPessoaRequest request)
    {
        var vacinasCadastradas = await _vacinaRepository.Listar();

        var pessoa = Pessoa.Criar(request.Nome, vacinasCadastradas);

        await _pessoaRepository.AddAsync(pessoa);
        await _pessoaRepository.UnityOfWork.SaveChangesAsync();

        return Result.Success;
    }

    public async Task<Result<ConsultarPessoaResponse>> ObterCardenetaPorPessoaId(long pessoaId)
    {
        var pessoa = await _pessoaRepository.ObterPorId(pessoaId);

        if (pessoa == null)
            return Result<ConsultarPessoaResponse>.Success(null);

        var grupoVacinacao = pessoa.CardenetaVacina.Vacinacoes.GroupBy(x => x.VacinaId);

        var vacinasResponse = grupoVacinacao.Select(grupo =>
        {
            var dosesResponse = grupo
                .Select(vacincacao => new ConsultaDoseAplicadaResponse(vacincacao.Id, vacincacao.NumeroDose, vacincacao.DataAplicacao))
                .ToArray();

            var vacina = grupo.FirstOrDefault().Vacina;

            return new ConsultaVacinaResponse(vacina.Id, vacina.Nome, vacina.QuantidadeDoses, vacina.QuantidadeReforcos, dosesResponse);
        }).ToArray();

        var cardeneta = new ConsultaCardenetaVacinaResponse(pessoa.CardenetaVacina.Id, vacinasResponse);

        var pessoaResponse = new ConsultarPessoaResponse(pessoa.Id, pessoa.Nome, cardeneta);

        return Result<ConsultarPessoaResponse>.Success(pessoaResponse);
    }

    public async Task<Result> DeletarPessoa(long pessoaId)
    {
        var pessoa = await _pessoaRepository.ObterPorId(pessoaId);

        if (pessoa == null)
            return Result.Fail("Pessoa não encontrada");

        await _pessoaRepository.DeleteAsync(pessoa);
        await _pessoaRepository.UnityOfWork.SaveChangesAsync();

        return Result.Success;
    }

    public async Task<Result> DeletarDose(long pessoaId, long doseId)
    {
        var pessoa = await _pessoaRepository.ObterPorId(pessoaId);

        if (pessoa == null)
            return Result.Fail("Pessoa não encontrada.");

        var doseDeletadaResult = pessoa.CardenetaVacina.RemoverVacinacao(doseId);

        if (!doseDeletadaResult)
            return doseDeletadaResult;

        await _pessoaRepository.UpdateAsync(pessoa);
        await _pessoaRepository.UnityOfWork.SaveChangesAsync();

        return Result.Success;
    }
}
