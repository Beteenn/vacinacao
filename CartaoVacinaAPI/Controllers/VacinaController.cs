using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Vacina;
using CartaoVacina.Core.Models.Responses.Vacina;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CartaoVacina.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacinaController : ControllerBase
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
        var resultado = await _vacinaService.Listar();

        return Ok(resultado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Cadastra uma nova vacina.")]
    public async Task<IActionResult> CriarVacina(CriarVacinaRequest request)
    {
        await _vacinaService.Criar(request);

        return Ok();
    }
}
