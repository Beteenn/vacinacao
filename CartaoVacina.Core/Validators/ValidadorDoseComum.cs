using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Results;

namespace CartaoVacina.Core.Validators;

public class ValidadorDoseComum : IValidadorDose
{
    public Result ValidarAplicacao(VacinacaoCollection vacinacoes, Vacina vacina, int numeroDose)
    {
        var vacinacao = vacinacoes.ObterUltimaVacinacaoPorTipoEId(vacina.Id);

        if (vacinacao == null)
            return ValidarPrimeiraAplicacao(vacina, numeroDose);

        return ValidarAplicacao(vacinacao, numeroDose);
    }

    public Result ValidarAplicacao(Vacinacao vacinacao, int numeroDose)
    {
        if (numeroDose == vacinacao.NumeroDose)
            return Result.Fail("Esta dose ja foi aplicada.");

        if (numeroDose > vacinacao.Vacina.QuantidadeDoses)
            return Result.Fail("Vacina não possui esta dose.");

        if (numeroDose > (vacinacao.NumeroDose + 1))
            return Result.Fail("Há doses faltantes para esta vacina.");

        return Result.Success;
    }

    public Result ValidarPrimeiraAplicacao(Vacina vacina, int numeroDose)
    {
        if (numeroDose > vacina.QuantidadeDoses)
            return Result.Fail("Vacina não possui esta dose.");

        if (numeroDose > 1)
            return Result.Fail("Há doses faltantes para esta vacina.");

        return Result.Success;
    }
}
