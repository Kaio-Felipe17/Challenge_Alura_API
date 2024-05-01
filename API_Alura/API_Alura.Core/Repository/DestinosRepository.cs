using API_Alura.Application.DTOs.Request;
using API_Alura.Application.Models;
using API_Alura.Infrastructure.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Alura.Core.Repository
{
    public interface IDestinosRepository
    {
        Task<Destinos> PostDestinosAsync(DestinosPostDTO dto);
        Task<Destinos?> GetDestinoAsync(string nome);
    }
    public class DestinosRepository : IDestinosRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public DestinosRepository(DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;   
            _context = context;
        }

        public async Task<Destinos> PostDestinosAsync(DestinosPostDTO dto)
        {
            var destinoPost = _mapper.Map<DestinosPostDTO, Destinos>(dto);

            _context.Destinos.Add(destinoPost);
            await _context.SaveChangesAsync();

            return destinoPost;
        }

        public async Task<Destinos?> GetDestinoAsync(string nome)
        {
            var destino = await _context.Destinos.Where(x => x.Nome == nome).FirstOrDefaultAsync();

            if (destino == default) throw new Exception("Nenhum destino foi encontrado");

            return destino;
        }
    }
}
