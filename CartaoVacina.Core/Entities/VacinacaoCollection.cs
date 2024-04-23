using CartaoVacina.Core.Enums;
using CartaoVacina.Core.Results;
using CartaoVacina.Core.Validators;

namespace CartaoVacina.Core.Entities;

public sealed class VacinacaoCollection : List<Vacinacao>
{
    private readonly Dictionary<TipoDose, IValidadorDose> _validadores = new()
    {
        {TipoDose.Comum, new ValidadorDoseComum() },
        {TipoDose.Reforco, new ValidadorDoseReforco() },
    };

    private IValidadorDose ObterValidador(TipoDose tipoDose)
    {
        _validadores.TryGetValue(tipoDose, out var validador);

        return validador;
    }

    internal Vacinacao? ObterUltimaVacinacaoPorTipoEId(long vacinaId, TipoDose tipoDose = TipoDose.Comum)
    {
        return this
            .OrderByDescending(x => x.NumeroDose)
            .FirstOrDefault(x => x.VacinaId == vacinaId && x.TipoDose == tipoDose);
    }

    private Vacinacao? ObterPorId(long vacinacaoId)
        => this.FirstOrDefault(x => x.Id == vacinacaoId);

    internal Result AdicionarVacinacao(Vacina vacina, int numeroDose, DateTime dataAplicacao, TipoDose tipoDose)
    {
        var aplicacaoValida = ObterValidador(tipoDose).ValidarAplicacao(this, vacina, numeroDose);

        if (!aplicacaoValida)
            return aplicacaoValida;

        Add(Vacinacao.Create(vacina.Id, numeroDose, dataAplicacao, tipoDose));

        return Result.Success;
    }

    internal Result RemoverVacinacao(long vacinacaoId)
    {
        var vacinacao = ObterPorId(vacinacaoId);

        if (vacinacao == null)
            return Result.Fail("Vacinacao não encontrada.");

        Remove(vacinacao);

        return Result.Success;
    }
}
