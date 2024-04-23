namespace CartaoVacina.Core.Entities;

public class Pessoa : Entity
{
    public string Nome { get; private set; }
    public CadernetaVacina CadernetaVacina { get; set; }

    private Pessoa() { }

    private Pessoa(string nome) : base()
    {
        Nome = nome;
        CadernetaVacina = CadernetaVacina.Criar(this);
    }

    public static Pessoa Criar(string nome, IEnumerable<Vacina> vacinas)
        =>new (nome);
}
