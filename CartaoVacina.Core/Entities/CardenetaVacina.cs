using CartaoVacina.Core.Results;

namespace CartaoVacina.Core.Entities;

public sealed class CardenetaVacina : Entity
{
    public Pessoa Pessoa { get; private set; }
    public long PessoaId { get; private set; }
    public ICollection<VacinaCardenetaVacina> Vacinas { get; private set; } = new List<VacinaCardenetaVacina>();

    private CardenetaVacina() { }

    private CardenetaVacina(Pessoa pessoa, IEnumerable<long> vacinasId)
    {
        Pessoa = pessoa;
        Vacinas = VacinaCardenetaVacina.Criar(this, vacinasId).ToList();
    }

    public static CardenetaVacina Criar(Pessoa pessoa, IEnumerable<long> vacinasId)
        => new (pessoa, vacinasId);

    public Result AplicarDose(long vacinaId, int numeroDose, DateTime dataAplicacao)
    {
        var vacina = Vacinas.FirstOrDefault(x => x.VacinaId == vacinaId);

        if (vacina == null)
            return Result.Fail("Vacina não encontrada");

        var doseAplicada = vacina.AplicarDose(numeroDose, dataAplicacao);

        return doseAplicada;
    }

    public Result DeletarDose(long doseId)
    {
        var vacina = Vacinas.FirstOrDefault(v => v.Doses.Any(d => d.Id == doseId));

        if (vacina == null)
            return Result.Fail("Dose não encontrada.");

        var dose = vacina.Doses.FirstOrDefault(x => x.Id == doseId);
        vacina.Doses.Remove(dose);

        return Result.Success;
    }
}
