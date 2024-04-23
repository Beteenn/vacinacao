using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Enums;
using CartaoVacina.Core.Results;

namespace CartaoVacina.Core.Validators;

public class ValidadorDoseReforco : IValidadorDose
{
    public Result ValidarAplicacao(VacinacaoCollection vacinacoes, Vacina vacina, int numeroDose)
    {
        var validacaoDosesComuns = ValidaPossuiTodasDosesComuns(vacinacoes, vacina);

        if (!validacaoDosesComuns)
            return validacaoDosesComuns;

        var vacinacaoReforco = vacinacoes.ObterUltimaVacinacaoPorTipoEId(vacina.Id, TipoDose.Reforco);

        if (vacinacaoReforco == null)
            return ValidarPrimeiraAplicacao(vacina, numeroDose);

        return ValidarAplicacao(vacinacaoReforco, numeroDose);
    }

    private static Result ValidaPossuiTodasDosesComuns(VacinacaoCollection vacinacoes, Vacina vacina)
    {
        var vacinacao = vacinacoes.ObterUltimaVacinacaoPorTipoEId(vacina.Id);

        if (vacinacao.NumeroDose < vacinacao.Vacina.QuantidadeDoses)
            return Result.Fail("Há doses faltantes para esta vacina.");

        return Result.Success;
    }

    public Result ValidarAplicacao(Vacinacao vacinacao, int numeroDose)
    {
        if (numeroDose == vacinacao.NumeroDose)
            return Result.Fail("Esta dose ja foi aplicada.");

        if (numeroDose > vacinacao.Vacina.QuantidadeReforcos)
            return Result.Fail("Vacina não possui este reforco.");

        if (numeroDose > (vacinacao.NumeroDose + 1))
            return Result.Fail("Há doses faltantes para esta vacina.");

        return Result.Success;
    }

    public Result ValidarPrimeiraAplicacao(Vacina vacina, int numeroDose)
    {
        if (numeroDose > vacina.QuantidadeReforcos)
            return Result.Fail("Vacina não possui este reforco.");

        if (numeroDose > 1)
            return Result.Fail("Há doses faltantes para esta vacina.");

        return Result.Success;
    }
}
