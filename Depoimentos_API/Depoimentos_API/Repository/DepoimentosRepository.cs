using Depoimentos_API.Context;
using Depoimentos_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Depoimentos_API.Repository
{
    public interface IDepoimentosRepository
    {
        Task PostDepoimentosAsync(IFormFile foto, string nome, string depoimento);

        Task GetDepoimentosAsync(int? pagina);
    }

    public class DepoimentosRepository
    {
        private readonly IDatabaseContext _context;

        public DepoimentosRepository(IDatabaseContext context)
        {
            _context = context;
        }

        private async Task<IActionResult> PostDepoimentosAsync(IFormFile foto, string nome, string depoimento)
        {
            
        }

        private async Task<List<DepoimentosGetDTO>> GetDepoimentosAsync(int? pagina)
        {
            
        }
    }
}
