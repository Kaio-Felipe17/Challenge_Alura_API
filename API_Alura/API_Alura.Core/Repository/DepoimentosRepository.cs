using API_Alura.Application.DTOs.Request;
using API_Alura.Application.DTOs.Response;
using API_Alura.Application.Models;
using API_Alura.Infrastructure.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Alura.Core.Repository
{
    public interface IDepoimentosRepository
    {
        Task<Depoimentos> PostDepoimentosAsync(DepoimentosPostDTO depoimento);

        Task<DepoimentosGetDTO> GetDepoimentosAsync(int id);

        Task<DepoimentosPutDTO> PutDepoimentosAsync(DepoimentosPutDTO dto);

        Task<bool> DeleteDepoimentosAsync(int id);

        Task<List<DepoimentosAleatoriosGetDTO>> GetDepoimentosAleatoriosAsync();
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

        public async Task<Depoimentos> PostDepoimentosAsync(DepoimentosPostDTO depoimento)
        {
            var depoimentoPost = _mapper.Map<DepoimentosPostDTO, Depoimentos>(depoimento);

            _context.Depoimentos.Add(depoimentoPost);
            await _context.SaveChangesAsync();

            return depoimentoPost;
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

        public async Task<DepoimentosPutDTO> PutDepoimentosAsync(DepoimentosPutDTO dto)
        {
            var depoiment = await _context.Depoimentos.FirstOrDefaultAsync(a => a.Id == dto.Id);

            if (depoiment == default) throw new Exception($"ID {dto.Id} inexistente.");

            _mapper.Map(dto, depoiment);

            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task<bool> DeleteDepoimentosAsync(int id)
        {
            var depoimentToDelete = await _context.Depoimentos.FirstOrDefaultAsync(a => a.Id == id);

            if (depoimentToDelete != default)
            {
                _context.Depoimentos.Remove(depoimentToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else throw new Exception($"ID {id} inexistente.");
        }

        public async Task<List<DepoimentosAleatoriosGetDTO>> GetDepoimentosAleatoriosAsync()
        {
            var randomDepoiments = new List<DepoimentosAleatoriosGetDTO>();

            for (int i = 1; i <= 3; i++)
            {
                var depoimentsCounting = await _context.Depoimentos.CountAsync();
                var randomNumber = new Random().Next(0, depoimentsCounting);
                var query = await _context.Depoimentos.Where(x => x.Id == randomNumber).FirstOrDefaultAsync();
                var randomDepoimentMapping = _mapper.Map<Depoimentos, DepoimentosAleatoriosGetDTO>(query);
                randomDepoiments.Add(randomDepoimentMapping);
            }

            return randomDepoiments;
        }
    }
}
