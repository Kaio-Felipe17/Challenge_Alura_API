using Depoimentos_API.DTOs;
using Depoimentos_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Depoimentos_API.Controllers
{
    public class DepoimentosController : Controller
    {
        private readonly IDepoimentosRepository _depoimentos;

        public DepoimentosController(IDepoimentosRepository depoimentos)
        {
            _depoimentos = depoimentos;
        }

        [HttpPost]
        public async Task<IActionResult> PostDepoimentos(
            IFormFile foto,
            [FromBody] string nome,
            [FromBody] string depoimento)
        {
            var response = await _depoimentos.PostDepoimentosAsync(foto, nome, depoimento);

            return Ok(response);
        }

        [HttpGet]
        public async Task<List<DepoimentosGetDTO>> GetDepoimentos(
            [FromBody] int? pagina)
        {
            var response = await _depoimentos.GetDepoimentosAsync(pagina);

            return response;
        }
    }
}
