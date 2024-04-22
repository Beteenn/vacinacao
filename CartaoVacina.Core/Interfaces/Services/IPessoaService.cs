using CartaoVacina.Core.Models.Requests.Pessoa;
using CartaoVacina.Core.Models.Responses.Pessoa;
using CartaoVacina.Core.Results;

namespace CartaoVacina.Core.Interfaces.Services;

public interface IPessoaService
{
    Task<Result<ConsultarPessoaResponse[]>> ListarPessoas();
    Task<Result> CriarPessoa(CriarPessoaRequest request);
    Task<Result<ConsultarPessoaResponse>> ObterCardenetaPorPessoaId(long pessoaId);
}
