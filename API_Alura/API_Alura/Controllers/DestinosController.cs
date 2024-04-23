using API_Alura.Application.DTOs.Request;
using API_Alura.Application.Models;
using API_Alura.Core.Repository;
using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Destinos> PostDestinos(DestinosPostDTO dto)
        {
            var response = await _destinos.PostDestinosAsync(dto);

            return response;
        }
    }
}
