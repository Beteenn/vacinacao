namespace CartaoVacina.Core.Entities;

public class Pessoa : Entity
{
    public string Nome { get; private set; }
    public CardenetaVacina CardenetaVacina { get; set; }

    private Pessoa() { }

    private Pessoa(string nome) : base()
    {
        Nome = nome;
        CardenetaVacina = CardenetaVacina.Criar(this);
    }

    public static Pessoa Criar(string nome, IEnumerable<Vacina> vacinas)
        =>new (nome);
}
