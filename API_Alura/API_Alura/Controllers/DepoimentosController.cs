using API_Alura.Application.DTOs.Request;
using API_Alura.Application.DTOs.Response;
using API_Alura.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Alura.Controllers;

[ApiController]
[Route("depoimentos")]
public class DepoimentosController : ControllerBase
{
    private readonly IDepoimentosRepository _depoimentos;

    public DepoimentosController(IDepoimentosRepository depoimentos)
    {
        _depoimentos = depoimentos;
    }

    /// <summary>
    /// Insere um novo depoimento.
    /// </summary>
    /// <param name="depoimento">Objeto para inserção</param>
    /// <returns></returns>
    [HttpPost("inserirDepoimento")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> InserirDepoimento([FromBody] InsereDepoimentoRequestDTO depoimento)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var response = await _depoimentos.InserirDepoimentoAsync(depoimento);

        return CreatedAtAction(nameof(ConsultaDepoimento), new { id = response.Id }, response);
    }

    /// <summary>
    /// Consulta um depoimento.
    /// </summary>
    /// <param name="id">Id do depoimento</param>
    /// <returns></returns>
    [HttpGet("consultaDepoimento")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ConsultaDepoimentoResponseDTO> ConsultaDepoimento([FromQuery][Required] int id)
    {
        var response = await _depoimentos.ConsultaDepoimentoAsync(id);

        return response;
    }

    /// <summary>
    /// Atualiza um depoimento existente.
    /// </summary>
    /// <param name="dto">Objeto para atualização</param>
    /// <returns></returns>
    [HttpPut("atualizaDepoimento")]
    [ProducesResponseType(typeof(AtualizaDepoimentoRequestDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AtualizaDepoimento([FromBody] AtualizaDepoimentoRequestDTO dto)
    {
        var response = await _depoimentos.AtualizaDepoimentoAsync(dto);

        return Ok(response);
    }

    /// <summary>
    /// Deleta um depoimento existente.
    /// </summary>
    /// <param name="id">Id do depoimento</param>
    /// <returns></returns>
    [HttpDelete("deletaDepoimento")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletaDepoimento([FromQuery] int id)
    {
        var response = await _depoimentos.DeletaDepoimentoAsync(id);

        return Ok(response);
    }

    /// <summary>
    /// Retorna 3 depoimentos de forma aleatória.
    /// </summary>
    /// <returns></returns>
    [HttpGet("depoimentos-home")]
    [ProducesResponseType(typeof(List<BuscaDepoimentosAleatoriosResponseDTO>), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscaDepoimentosAleatorios()
    {
        var response = await _depoimentos.BuscaDepoimentosAleatoriosAsync();

        return Ok(response);
    }
}
