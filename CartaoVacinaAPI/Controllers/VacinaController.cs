using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Vacina;
using CartaoVacina.Core.Models.Responses.Vacina;
using CartaoVacina.Core.Results;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CartaoVacina.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacinaController : Controller
{
    private readonly IVacinaService _vacinaService;

    public VacinaController(IVacinaService vacinaService)
    {
        _vacinaService = vacinaService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ConsultaVacinaResponse[]), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Lista vacinas cadastradas.")]
    public async Task<IActionResult> ListarVacinas()
    {
        return TratarResultado(await _vacinaService.Listar());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Cadastra uma nova vacina.")]
    public async Task<IActionResult> CriarVacina(CriarVacinaRequest request)
    {
        return TratarResultado(await _vacinaService.Criar(request));
    }

    [HttpPost("aplicar-dose")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Aplica uma nova dose da vacina.")]
    public async Task<IActionResult> AplicarDose(AplicarNovaDoseRequest request)
    {
        return TratarResultado(await _vacinaService.AplicarDose(request));
    }
}
