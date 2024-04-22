using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Vacina;
using CartaoVacina.Core.Models.Responses.Vacina;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace CartaoVacina.API.Controllers;

[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class VacinaController : Controller
{
    private readonly IVacinaService _vacinaService;

    public VacinaController(IVacinaService vacinaService)
    {
        _vacinaService = vacinaService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ConsultaVacinaSimplificadaResponse[]), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
}
