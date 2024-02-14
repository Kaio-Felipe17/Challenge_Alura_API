using Depoimentos_API.Context;
using Depoimentos_API.DTOs;
using Depoimentos_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Depoimentos_API.Repository
{
    public interface IDepoimentosRepository
    {
        Task<IActionResult> PostDepoimentosAsync(DepoimentosPostDTO depoimento);
    }

    public class DepoimentosRepository : IDepoimentosRepository
    {
        private readonly DatabaseContext _context;

        public DepoimentosRepository(DatabaseContext context)
        {
            _context = context;
        }

        private async Task<IActionResult> PostDepoimentosAsync(DepoimentosPostDTO depoimento)
        {
            var depoimentoPost = new Depoimentos
            {
                Foto = depoimento.Foto,
                Nome = depoimento.Nome,
                Depoimento = depoimento.Depoimento
            };

            var postResponse = await _context.Depoimentos.AddAsync(depoimentoPost);

            return (IActionResult)postResponse;
        }

        Task<IActionResult> IDepoimentosRepository.PostDepoimentosAsync(DepoimentosPostDTO depoimento)
        {
            throw new NotImplementedException();
        }
    }
}
