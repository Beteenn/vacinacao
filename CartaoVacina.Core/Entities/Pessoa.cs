namespace CartaoVacina.Core.Entities;

public class Pessoa : Entity
{
    public string Nome { get; private set; }

    private Pessoa() { }

    private Pessoa(string nome) : base()
    {
        Nome = nome;
    }

    public static Pessoa Criar(string nome)
    {
        return new Pessoa(nome);
    }
}
