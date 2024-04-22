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

        var vacinasReponse = pessoa.CardenetaVacina.Vacinas
            .Select(v =>
            {
                var dosesResponse = v.Doses.Select(d => new ConsultaDoseAplicadaResponse(d.NumeroDose, d.DataAplicacao)).ToArray();

                return new ConsultaVacinaResponse(v.Vacina.Id, v.Vacina.Nome, v.Vacina.QuantidadeDoses, v.Vacina.QuantidadeReforcos, dosesResponse);
            });

        var cardeneta = new ConsultaCardenetaVacinaResponse(pessoa.CardenetaVacina.Id, vacinasReponse.ToArray());

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
}
