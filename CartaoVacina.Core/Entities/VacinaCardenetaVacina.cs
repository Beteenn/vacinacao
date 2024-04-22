using CartaoVacina.Core.Results;

namespace CartaoVacina.Core.Entities;

public sealed class VacinaCardenetaVacina : Entity
{
    public CardenetaVacina Cardeneta { get; private set; }
    public long CardenetaId { get; private set; }
    public Vacina Vacina { get; private set; }
    public long VacinaId { get; private set; }
    public ICollection<DoseVacinaCardeneta> Doses { get; private set; } = new List<DoseVacinaCardeneta>();
    
    private int UltimaDoseAplicada => Doses.LastOrDefault()?.NumeroDose ?? 0;

    private VacinaCardenetaVacina() { }

    private VacinaCardenetaVacina(CardenetaVacina cardeneta, long vacinaId)
    {
        Cardeneta = cardeneta;
        VacinaId = vacinaId;
    }

    public static VacinaCardenetaVacina Criar(CardenetaVacina cardeneta, long vacinaId)
        => new (cardeneta, vacinaId);

    public static IEnumerable<VacinaCardenetaVacina> Criar(CardenetaVacina cardeneta, IEnumerable<long> vacinasId)
        => vacinasId.Select(vacina => new VacinaCardenetaVacina(cardeneta, vacina));

    private Result ValidarAplicacao(int numeroDose)
    {
        if (numeroDose > Vacina.QuantidadeDoses)
            return Result.Fail("Vacina não possui esta dose.");

        if (numeroDose == UltimaDoseAplicada)
            return Result.Fail("Esta dose ja foi aplicada.");

        if (numeroDose > (UltimaDoseAplicada + 1))
            return Result.Fail("Há doses faltantes para esta vacina.");

        return Result.Success;
    }

    public Result AplicarDose(int numeroDose, DateTime dataAplicacao)
    {
        var aplicacaoValida = ValidarAplicacao(numeroDose);

        if (!aplicacaoValida)
            return aplicacaoValida;

        Doses.Add(DoseVacinaCardeneta.Create(numeroDose, dataAplicacao));

        return Result.Success;
    }
}
