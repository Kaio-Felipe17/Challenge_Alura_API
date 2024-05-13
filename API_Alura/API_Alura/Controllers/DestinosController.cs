using API_Alura.Application.DTOs.Request;
using API_Alura.Application.Models;
using API_Alura.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Alura.Controllers
{
    [ApiController]
    [Route("destinos")]
    public class DestinosController : ControllerBase
    {
        private readonly IDestinosRepository _destinos;

        public DestinosController(IDestinosRepository destinos)
        {
            _destinos = destinos;
        }

        /// <summary>
        /// Insere um novo destino.
        /// </summary>
        /// <param name="dto">Objeto para inserção</param>
        /// <returns></returns>
        [HttpPost("inserirDestino")]
        [ProducesResponseType(typeof(Destino), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Destino> InsereDestino(InsereDestinoRequestDTO dto)
        {
            var response = await _destinos.InsereDestinoAsync(dto);

            return response;
        }

        /// <summary>
        /// Consulta um destino.
        /// </summary>
        /// <param name="nome">Nome do destino</param>
        /// <returns></returns>
        [HttpGet("consultaDestino")]
        [ProducesResponseType(typeof(Destino), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Destino?> ConsultaDestino([FromQuery][Required] string nome)
        {
            var response = await _destinos.ConsultaDestinoAsync(nome);

            return response;
        }

        /// <summary>
        /// Atualiza um destino.
        /// </summary>
        /// <param name="dto">Objeto para atualização</param>
        /// <returns></returns>
        [HttpPut("atualizaDestino")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizaDestino([FromBody] AtualizaDestinoRequestDTO dto)
        {
            var response = await _destinos.AtualizaDestinoAsync(dto);

            return Ok(response);
        }

        /// <summary>
        /// Exclui um destino.
        /// </summary>
        /// <param name="id">Id do destino</param>
        /// <returns></returns>
        [HttpDelete("deletaDestino")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<bool> DeletaDestino([FromQuery][Required] int id)
        {
            var response = await _destinos.DeletaDestinoAsync(id);

            return response;
        }
    }
}
