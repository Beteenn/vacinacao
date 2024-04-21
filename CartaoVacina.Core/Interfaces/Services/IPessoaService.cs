using CartaoVacina.Core.Models.Requests.Pessoa;

namespace CartaoVacina.Core.Interfaces.Services;

public interface IPessoaService
{
    Task CriarPessoa(CriarPessoaRequest request);
}
