namespace CartaoVacina.Core.Entities;

public sealed class CardenetaVacina : Entity
{
    public Pessoa Pessoa { get; private set; }
    public long PessoaId { get; private set; }
    public ICollection<VacinaCardenetaVacina> Vacinas { get; private set; } = new List<VacinaCardenetaVacina>();

    private CardenetaVacina() { }

    private CardenetaVacina(Pessoa pessoa, IEnumerable<Vacina> vacinas)
    {
        Pessoa = pessoa;
        Vacinas = VacinaCardenetaVacina.Criar(this, vacinas).ToList();
    }

    public static CardenetaVacina Criar(Pessoa pessoa, IEnumerable<Vacina> vacinas)
        => new (pessoa, vacinas);
}
