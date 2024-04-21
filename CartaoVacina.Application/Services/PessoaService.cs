using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Pessoa;
using CartaoVacina.Core.Models.Responses.Pessoa;
using CartaoVacina.Core.Models.Responses.Vacina;
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

    public async Task<ConsultarPessoaResponse[]> ListarPessoas()
    {
        var pessoas = await _pessoaRepository.ListarPessoas();

        return pessoas.Select(pessoa =>
        {
            var vacinasReponse = pessoa.CardenetaVacina.Vacinas
                .Select(v => new ConsultaVacinaResponse(v.Vacina.Id, v.Vacina.Nome, v.Vacina.QuantidadeDoses, v.Vacina.QuantidadeReforcos));

            var cardeneta = new ConsultaCardenetaVacinaResponse(pessoa.CardenetaVacina.Id, vacinasReponse.ToArray());

            return new ConsultarPessoaResponse(pessoa.Id, pessoa.Nome, cardeneta);
        }).ToArray();
    }

    public async Task CriarPessoa(CriarPessoaRequest request)
    {
        var vacinasCadastradas = await _vacinaRepository.Listar();

        var pessoa = Pessoa.Criar(request.Nome, vacinasCadastradas);

        await _pessoaRepository.AddAsync(pessoa);
        await _pessoaRepository.UnityOfWork.SaveChangesAsync();
    }
}
