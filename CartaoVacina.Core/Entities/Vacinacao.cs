namespace CartaoVacina.Core.Entities;

public sealed class Vacinacao : Entity
{
    public CadernetaVacina Caderneta { get; private set; }
    public long CadernetaId { get; private set; }
    public Vacina Vacina { get; private set; }
    public long VacinaId { get; private set; }
    public DateTime DataAplicacao { get; private set; }
    public int NumeroDose { get; private set; }

    private Vacinacao() { }

    private Vacinacao(long vacinaId, int numeroDose, DateTime dataAplicacao)
    {
        VacinaId = vacinaId;
        NumeroDose = numeroDose;
        DataAplicacao = dataAplicacao;
    }

    internal static Vacinacao Create(long vacinaId, int numeroDose, DateTime dataAplicacao)
    {
        return new Vacinacao(vacinaId, numeroDose, dataAplicacao);
    }
}
