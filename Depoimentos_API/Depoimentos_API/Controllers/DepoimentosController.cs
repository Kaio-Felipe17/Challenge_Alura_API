using Depoimentos_API.DTOs;
using Depoimentos_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Depoimentos_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepoimentosController : Controller
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
    }
}
