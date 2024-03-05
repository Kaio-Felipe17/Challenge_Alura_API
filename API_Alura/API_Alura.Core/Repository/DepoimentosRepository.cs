using API_Alura.Application.DTOs;
using API_Alura.Application.Models;
using API_Alura.Infrastructure.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Alura.Core.Repository
{
    public interface IDepoimentosRepository
    {
        Task<string> PostDepoimentosAsync(DepoimentosPostDTO depoimento);

        Task<DepoimentosGetDTO> GetDepoimentosAsync(int id);

        Task<string> PutDepoimentosAsync(DepoimentosPutDTO dto);
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

            return $"Depoimento de {depoimentoPost.Nome} inserido com sucesso.";
        }

        public async Task<DepoimentosGetDTO> GetDepoimentosAsync(int id)
        {
            var query = await (from a in _context.Depoimentos.Where(a => a.Id == id)

                               select new DepoimentosGetDTO
                               {
                                   Id = a.Id,
                                   Foto = Convert.ToBase64String(a.Foto),
                                   Nome = a.Nome,
                                   Depoimento = a.Depoimento
                               })
                .FirstOrDefaultAsync();

            return query;
        }

        public async Task<string> PutDepoimentosAsync(DepoimentosPutDTO dto)
        {
            var depoiment = await _context.Depoimentos.FirstOrDefaultAsync(a => a.Id == dto.Id);

            if (depoiment == default)
                throw new Exception($"ID {dto.Id} inexistente.");

            _mapper.Map(dto, depoiment);
            await _context.SaveChangesAsync();
            return $"Id {dto.Id} atualizado com sucesso.";
        }
    }
}
