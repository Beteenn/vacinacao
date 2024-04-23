using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Pessoa;
using CartaoVacina.Core.Models.Requests.Vacina;
using CartaoVacina.Core.Models.Responses.Pessoa;
using CartaoVacina.Core.Results;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace CartaoVacina.API.Controllers;

[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class CadernetaController : Controller
{
    private readonly IPessoaService _pessoaService;
    private readonly IVacinaService _vacinaService;

    public CadernetaController(IPessoaService pessoaService, IVacinaService vacinaService)
    {
        _pessoaService = pessoaService ?? throw new ArgumentNullException();
        _vacinaService = vacinaService ?? throw new ArgumentNullException();
    }

    [HttpGet("{pessoaId}")]
    [ProducesResponseType(typeof(ConsultarPessoaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(Summary = "Obter caderneta por pessoa.")]
    public async Task<IActionResult> ObterCadernetaPorPessoaId(long pessoaId)
    {
        return TratarResultado(await _pessoaService.ObterCadernetaPorPessoaId(pessoaId));
    }

    [HttpPost("dose")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Aplica uma nova dose da vacina.")]
    public async Task<IActionResult> AplicarDose(AplicarNovaDoseRequest request)
    {
        return TratarResultado(await _vacinaService.AplicarDose(request));
    }

    [HttpDelete("{pessoaId}/dose/{doseId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Deletar uma dose aplicada.")]
    public async Task<IActionResult> DeletarDose(long pessoaId, long doseId)
    {
        return TratarResultado(await _pessoaService.DeletarDose(pessoaId, doseId));
    }
}
