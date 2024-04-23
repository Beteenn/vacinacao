using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Results;

namespace CartaoVacina.Core.Validators;

public interface IValidadorDose
{
    Result ValidarAplicacao(VacinacaoCollection vacinacoes, Vacina vacina, int numeroDose);
    Result ValidarPrimeiraAplicacao(Vacina vacina, int numeroDose);
    Result ValidarAplicacao(Vacinacao vacinacao, int numeroDose);
}
