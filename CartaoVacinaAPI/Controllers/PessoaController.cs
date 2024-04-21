using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Pessoa;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    public async Task<IActionResult> CriarPessoa(CriarPessoaRequest request)
    {
        await _pessoaService.CriarPessoa(request);

        return Ok();
    }
}
