using CartaoVacina.Core.Models.Responses.Vacina;

namespace CartaoVacina.Core.Models.Responses.Pessoa;

public record ConsultarPessoaResponse(long Id, string Nome, ConsultaCardenetaVacinaResponse? Cardeneta);

