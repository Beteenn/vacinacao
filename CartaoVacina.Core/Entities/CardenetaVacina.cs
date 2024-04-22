using CartaoVacina.Core.Results;

namespace CartaoVacina.Core.Entities;

public sealed class CardenetaVacina : Entity
{
    public Pessoa Pessoa { get; private set; }
    public long PessoaId { get; private set; }
    public VacinacaoCollection Vacinacoes { get; private set; } = new();

    private CardenetaVacina() { }

    private CardenetaVacina(Pessoa pessoa)
    {
        Pessoa = pessoa;
    }

    public static CardenetaVacina Criar(Pessoa pessoa)
        => new (pessoa);

    public Result AdicionarVacinacao(Vacina vacina, int numeroDose, DateTime dataAplicacao)
        => Vacinacoes.AdicionarVacinacao(vacina, numeroDose, dataAplicacao);

    public Result RemoverVacinacao(long vacinacaoId)
        => Vacinacoes.RemoverVacinacao(vacinacaoId);
}
