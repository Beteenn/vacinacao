namespace CartaoVacina.Core.Entities;

public class Pessoa : Entity
{
    public string Nome { get; private set; }
    public CardenetaVacina CardenetaVacina { get; set; }

    private Pessoa() { }

    private Pessoa(string nome) : base()
    {
        Nome = nome;
    }

    public static Pessoa Criar(string nome, IEnumerable<Vacina> vacinas)
    {
        var pessoa = new Pessoa(nome);
        pessoa.AdicionarCardeneta(vacinas);

        return pessoa;
    }

    private void AdicionarCardeneta(IEnumerable<Vacina> vacinas)
    {
        CardenetaVacina = CardenetaVacina.Criar(this, vacinas);
    }
}
