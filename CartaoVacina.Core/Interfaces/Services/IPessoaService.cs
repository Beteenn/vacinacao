using CartaoVacina.Core.Models.Requests.Pessoa;
using CartaoVacina.Core.Models.Responses.Pessoa;

namespace CartaoVacina.Core.Interfaces.Services;

public interface IPessoaService
{
    Task<ConsultarPessoaResponse[]> ListarPessoas();
    Task CriarPessoa(CriarPessoaRequest request);
}
