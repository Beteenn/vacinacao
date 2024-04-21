namespace CartaoVacina.Core.Models.Requests.Vacina;

public record CriarVacinaRequest(string Nome, int QuantidadeDoses, int QuantidadeReforcos);
