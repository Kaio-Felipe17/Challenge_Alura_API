using API_Alura.Application.DTOs;
using API_Alura.Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_Alura.Controllers;

[ApiController]
[Route("controller")]
public class DepoimentosController : ControllerBase
{
    private readonly IDepoimentosRepository _depoimentos;

    public DepoimentosController(IDepoimentosRepository depoimentos)
    {
        _depoimentos = depoimentos;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> PostDepoimentos([FromBody] DepoimentosPostDTO depoimento)
    {
        var response = await _depoimentos.PostDepoimentosAsync(depoimento);

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<DepoimentosGetDTO> GetDepoimentos([FromQuery] int id)
    {
        var response = await _depoimentos.GetDepoimentosAsync(id);

        return response;
    }

    [HttpPut]
    public async Task<string> PutDepoimentos([FromBody] DepoimentosPutDTO dto)
    {
        var response = await _depoimentos.PutDepoimentosAsync(dto);

        return response;
    }
}
