using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Pessoa;
using CartaoVacina.Core.Models.Responses.Pessoa;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CartaoVacina.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService ?? throw new ArgumentNullException();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ConsultarPessoaResponse[]), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Listar pessoas cadastradas.")]
    public async Task<IActionResult> ListarPessoas()
    {
        var resultado = await _pessoaService.ListarPessoas();

        return Ok(resultado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Cadastra uma nova pessoa.")]
    public async Task<IActionResult> CriarPessoa(CriarPessoaRequest request)
    {
        await _pessoaService.CriarPessoa(request);

        return Ok();
    }
}
