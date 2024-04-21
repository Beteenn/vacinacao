using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Pessoa;

namespace CartaoVacina.Application.Services;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaService(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task CriarPessoa(CriarPessoaRequest request)
    {
        var pessoa = Pessoa.Criar(request.Nome);

        await _pessoaRepository.AddAsync(pessoa);
    }
}
