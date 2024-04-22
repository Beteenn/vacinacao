using CartaoVacina.Core.Results;

namespace CartaoVacina.Core.Entities;

public class VacinacaoCollection : List<Vacinacao>
{
    private Vacinacao? ObterUltimaVacinacaoPorVacinaId(long vacinaId)
    {
        return this
            .OrderByDescending(x => x.NumeroDose)
            .FirstOrDefault(x => x.VacinaId == vacinaId);
    }

    private Vacinacao? ObterPorId(long vacinacaoId)
        => this.FirstOrDefault(x => x.Id == vacinacaoId);

    private Result ValidarAplicacao(Vacinacao vacinacao, int numeroDose)
    {
        if (numeroDose > vacinacao.Vacina.QuantidadeDoses)
            return Result.Fail("Vacina não possui esta dose.");

        if (numeroDose == vacinacao.NumeroDose)
            return Result.Fail("Esta dose ja foi aplicada.");

        if (numeroDose > (vacinacao.NumeroDose + 1))
            return Result.Fail("Há doses faltantes para esta vacina.");

        return Result.Success;
    }

    private Result ValidarPrimeiraAplicacao(Vacina vacina, int numeroDose)
    {
        if (numeroDose > vacina.QuantidadeDoses)
            return Result.Fail("Vacina não possui esta dose.");

        if (numeroDose > 1)
            return Result.Fail("Há doses faltantes para esta vacina.");

        return Result.Success;
    }

    internal Result AdicionarVacinacao(Vacina vacina, int numeroDose, DateTime dataAplicacao)
    {
        var vacinacao = ObterUltimaVacinacaoPorVacinaId(vacina.Id);

        if (vacinacao == null)
        {
            var aplicacaoValida = ValidarPrimeiraAplicacao(vacina, numeroDose);

            if (!aplicacaoValida)
                return aplicacaoValida;
        }
        else
        {
            var aplicacaoValida = ValidarAplicacao(vacinacao, numeroDose);

            if (!aplicacaoValida)
                return aplicacaoValida;
        }

        Add(Vacinacao.Create(vacina.Id, numeroDose, dataAplicacao));

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
