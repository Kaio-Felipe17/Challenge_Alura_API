using API_Alura.Application.DTOs.Request;
using API_Alura.Application.Models;
using API_Alura.Infrastructure.Context;
using AutoMapper;

namespace API_Alura.Core.Repository
{
    public interface IDestinosRepository
    {
        Task<Destinos> PostDestinosAsync(DestinosPostDTO dto);
    }
    public class DestinosRepository: IDestinosRepository
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
    }
}
