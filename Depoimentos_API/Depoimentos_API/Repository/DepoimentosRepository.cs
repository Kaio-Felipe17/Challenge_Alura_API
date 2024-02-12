using Depoimentos_API.Context;
using Depoimentos_API.DTOs;
using Depoimentos_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Depoimentos_API.Repository
{
    public interface IDepoimentosRepository
    {
        Task<IActionResult> PostDepoimentosAsync(
            IFormFile foto, 
            string nome, 
            string depoimento);
    }

    public class DepoimentosRepository
    {
        private readonly IDatabaseContext _context;

        public DepoimentosRepository(IDatabaseContext context)
        {
            _context = context;
        }

        private async Task<IActionResult> PostDepoimentosAsync(
            IFormFile foto, 
            string nome, 
            string depoimento)
        {
            var depoimentoPost = new Depoimentos
            {
                Foto = foto,
                Nome = nome,
                Depoimento = depoimento
            };

            var postResponse = await _context.Depoimentos.AddAsync(depoimentoPost);

            return (IActionResult)postResponse;
        }
    }
}
