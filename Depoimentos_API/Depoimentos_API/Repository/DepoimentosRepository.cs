using AutoMapper;
using Depoimentos_API.Context;
using Depoimentos_API.DTOs;
using Depoimentos_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Depoimentos_API.Repository
{
    public interface IDepoimentosRepository
    {
        Task<string> PostDepoimentosAsync(DepoimentosPostDTO depoimento);
    }

    public class DepoimentosRepository : IDepoimentosRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public DepoimentosRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> PostDepoimentosAsync(DepoimentosPostDTO depoimento)
        {
            var depoimentoPost = _mapper.Map<Depoimentos>(depoimento);

            await _context.Depoimentos.AddAsync(depoimentoPost);
            await _context.SaveChangesAsync();

            return $"Depoimento de {depoimentoPost.Nome} inserido com sucesso";
        }
    }
}
