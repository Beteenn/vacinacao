namespace CartaoVacina.Core.Entities;

public class Vacina : Entity
{
    public string Nome { get; set; }
    public int QuantidadeDoses { get; private set; }
    public int QuantidadeReforcos { get; private set; }

    private Vacina() { }

    private Vacina(string nome, int quantidadeDoses, int quantidadeReforcos)
    {
        Nome = nome;
        QuantidadeDoses = quantidadeDoses;
        QuantidadeReforcos = quantidadeReforcos;
    }

    public static Vacina Criar(string nome, int doses, int reforcos)
        => new Vacina(nome, doses, reforcos);

}
