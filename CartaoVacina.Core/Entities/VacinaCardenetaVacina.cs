namespace CartaoVacina.Core.Entities;

public sealed class VacinaCardenetaVacina : Entity
{
    public CardenetaVacina Cardeneta { get; private set; }
    public long CardenetaId { get; private set; }
    public Vacina Vacina { get; private set; }
    public long VacinaId { get; private set; }
    public ICollection<DoseVacinaCardeneta> Doses { get; private set; }

    private VacinaCardenetaVacina() { }

    private VacinaCardenetaVacina(CardenetaVacina cardeneta, Vacina vacina)
    {
        Cardeneta = cardeneta;
        Vacina = vacina;
    }

    public static VacinaCardenetaVacina Criar(CardenetaVacina cardeneta, Vacina vacina)
        => new (cardeneta, vacina);

    public static IEnumerable<VacinaCardenetaVacina> Criar(CardenetaVacina cardeneta, IEnumerable<Vacina> vacinas)
        => vacinas.Select(vacina => new VacinaCardenetaVacina(cardeneta, vacina));
}
