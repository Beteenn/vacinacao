namespace CartaoVacina.Core.Models.Responses.Vacina;

public record ConsultaVacinaResponse(long Id, string Nome, int QuantidadeDoses,
    int QuantidadeReforcos, ConsultaDoseAplicadaResponse[] Doses, ConsultaDoseAplicadaResponse[] Reforcos);
