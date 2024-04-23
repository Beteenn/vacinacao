using CartaoVacina.Core.Enums;

namespace CartaoVacina.Core.Models.Requests.Vacina;

public record AplicarNovaDoseRequest
{
    public long PessoaId { get; init; }
    public long VacinaId { get; init; }
    public int NumeroDose { get; init; }
    public DateTime DataAplicacao { get; init; } = DateTime.Now;
    public TipoDose Tipo { get; init; }
}
