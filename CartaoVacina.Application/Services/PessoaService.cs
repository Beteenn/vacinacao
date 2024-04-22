using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Pessoa;
using CartaoVacina.Core.Models.Responses.Pessoa;
using CartaoVacina.Core.Models.Responses.Vacina;
using CartaoVacina.Core.Results;
using System.Linq;

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

    public async Task<Result<ConsultarPessoaResponse[]>> ListarPessoas()
    {
        var pessoas = await _pessoaRepository.ListarPessoas();

        var pessoasResponse = pessoas.Select(pessoa =>
        {
            var vacinasReponse = pessoa.CardenetaVacina.Vacinas
                .Select(v =>
                {
                    var dosesResponse = v.Doses.Select(d => new ConsultaDoseAplicadaResponse(d.NumeroDose, d.DataAplicacao)).ToArray();

                    return new ConsultaVacinaResponse(v.Vacina.Id, v.Vacina.Nome, v.Vacina.QuantidadeDoses, v.Vacina.QuantidadeReforcos, dosesResponse);
                });

            var cardeneta = new ConsultaCardenetaVacinaResponse(pessoa.CardenetaVacina.Id, vacinasReponse.ToArray());

            return new ConsultarPessoaResponse(pessoa.Id, pessoa.Nome, cardeneta);
        }).ToArray();

        return Result<ConsultarPessoaResponse[]>.Success(pessoasResponse);
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
}
