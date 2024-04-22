namespace CartaoVacina.Core.Entities;

public sealed class DoseVacinaCardeneta : Entity
{
    public VacinaCardenetaVacina CardenetaVacina { get; private set; }
    public long CardenetaVacinaId { get; private set; }
    public int NumeroDose { get; private set; }
    public DateTime DataAplicacao { get; private set; }

    private DoseVacinaCardeneta() { }

    public DoseVacinaCardeneta(int numeroDose, DateTime dataAplicacao)
    {
        NumeroDose = numeroDose;
        DataAplicacao = dataAplicacao;
    }

    public static DoseVacinaCardeneta Create(int numeroDose, DateTime dataAplicacao)
        => new(numeroDose, dataAplicacao);
}
