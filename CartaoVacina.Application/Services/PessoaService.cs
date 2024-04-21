using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Pessoa;
using CartaoVacina.Core.Models.Responses.Pessoa;

namespace CartaoVacina.Application.Services;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaService(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository ?? throw new ArgumentNullException();
    }

    public async Task<ConsultarPessoaResponse[]> ListarPessoas()
    {
        var pessoas = await _pessoaRepository.ListarPessoas();

        return pessoas.Select(x => new ConsultarPessoaResponse(x.Id, x.Nome)).ToArray();
    }

    public async Task CriarPessoa(CriarPessoaRequest request)
    {
        var pessoa = Pessoa.Criar(request.Nome);

        await _pessoaRepository.AddAsync(pessoa);
        await _pessoaRepository.UnityOfWork.SaveChangesAsync();
    }
}
