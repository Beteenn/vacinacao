﻿using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.Core.Models.Requests.Pessoa;
using CartaoVacina.Core.Models.Responses.Pessoa;
using CartaoVacina.Core.Results;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace CartaoVacina.API.Controllers;

[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class PessoaController : Controller
{
    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService ?? throw new ArgumentNullException();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ConsultarPessoaSimplificadaResponse[]), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(Summary = "Listar pessoas cadastradas.")]
    public async Task<IActionResult> ListarPessoas()
    {
        return TratarResultado(await _pessoaService.ListarPessoas());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Cadastra uma nova pessoa com uma caderneta de vacina.")]
    public async Task<IActionResult> CriarPessoa(CriarPessoaRequest request)
    {
        return TratarResultado(await _pessoaService.CriarPessoa(request));
    }

    [HttpDelete("{pessoaId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Deletar uma pessoa.")]
    public async Task<IActionResult> DeletarPessoa(long pessoaId)
    {
        return TratarResultado(await _pessoaService.DeletarPessoa(pessoaId));
    }
}
