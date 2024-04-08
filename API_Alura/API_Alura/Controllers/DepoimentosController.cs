using API_Alura.Application.DTOs;
using API_Alura.Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_Alura.Controllers;

[ApiController]
[Route("[controller]")]
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
    public async Task<IActionResult> PostDepoimentos(
        [FromBody] DepoimentosPostDTO depoimento)
    {
        var response = await _depoimentos.PostDepoimentosAsync(depoimento);

        return Ok(response);
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
    public async Task<DepoimentosGetDTO> GetDepoimentos([FromQuery] int id)
    {
        var response = await _depoimentos.GetDepoimentosAsync(id);

        return response;
    }

    /// <summary>
    /// Atualiza um depoimento existente.
    /// </summary>
    /// <param name="dto">Objeto para atualização</param>
    /// <returns></returns>
    [HttpPut("atualizaDepoimento")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<string> PutDepoimentos([FromBody] DepoimentosPutDTO dto)
    {
        var response = await _depoimentos.PutDepoimentosAsync(dto);

        return response;
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
    public async Task<IActionResult> DeleteDepoimentos([FromQuery] int id)
    {
        var response = await _depoimentos.DeleteDepoimentosAsync(id);

        return Ok(response);
    }
}
