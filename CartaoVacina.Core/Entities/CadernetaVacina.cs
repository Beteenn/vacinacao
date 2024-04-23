using CartaoVacina.Core.Enums;
using CartaoVacina.Core.Results;

namespace CartaoVacina.Core.Entities;

public sealed class CadernetaVacina : Entity
{
    public Pessoa Pessoa { get; private set; }
    public long PessoaId { get; private set; }
    public VacinacaoCollection Vacinacoes { get; private set; } = new();

    private CadernetaVacina() { }

    private CadernetaVacina(Pessoa pessoa)
    {
        Pessoa = pessoa;
    }

    public static CadernetaVacina Criar(Pessoa pessoa)
        => new (pessoa);

    public Result AdicionarVacinacao(Vacina vacina, int numeroDose, DateTime dataAplicacao, TipoDose tipoDose)
        => Vacinacoes.AdicionarVacinacao(vacina, numeroDose, dataAplicacao, tipoDose);

    public Result RemoverVacinacao(long vacinacaoId)
        => Vacinacoes.RemoverVacinacao(vacinacaoId);
}
