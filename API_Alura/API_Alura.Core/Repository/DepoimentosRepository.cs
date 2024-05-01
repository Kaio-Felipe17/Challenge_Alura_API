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
        Task<Depoimento> InserirDepoimentoAsync(InsereDepoimentoRequestDTO depoimento);

        Task<ConsultaDepoimentoResponseDTO> ConsultaDepoimentoAsync(int id);

        Task<AtualizaDepoimentoRequestDTO> AtualizaDepoimentoAsync(AtualizaDepoimentoRequestDTO dto);

        Task<bool> DeletaDepoimentoAsync(int id);

        Task<List<BuscaDepoimentosAleatoriosResponseDTO>> BuscaDepoimentosAleatoriosAsync();
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

        public async Task<Depoimento> InserirDepoimentoAsync(InsereDepoimentoRequestDTO depoimento)
        {
            var depoimentoMap = _mapper.Map<InsereDepoimentoRequestDTO, Depoimento>(depoimento);

            _context.Depoimentos.Add(depoimentoMap);
            await _context.SaveChangesAsync();

            return depoimentoMap;
        }

        public async Task<ConsultaDepoimentoResponseDTO> ConsultaDepoimentoAsync(int id)
        {
            var query = await (from a in _context.Depoimentos.Where(a => a.Id == id)

                select new ConsultaDepoimentoResponseDTO
                {
                    Id = a.Id,
                    Foto = Convert.ToBase64String(a.Foto),
                    Nome = a.Nome,
                    Depoimento = a.DepoimentoUsuario
                })
                .FirstOrDefaultAsync();

            return query;
        }

        public async Task<AtualizaDepoimentoRequestDTO> AtualizaDepoimentoAsync(AtualizaDepoimentoRequestDTO dto)
        {
            var searchDepoiment = await _context.Depoimentos.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();

            if (searchDepoiment == default) throw new Exception($"ID {dto.Id} inexistente.");

            _mapper.Map(dto, searchDepoiment);
            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task<bool> DeletaDepoimentoAsync(int id)
        {
            var searchDepoiment = await _context.Depoimentos.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (searchDepoiment == default) throw new Exception($"ID {id} inexistente.");

            _context.Depoimentos.Remove(searchDepoiment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<BuscaDepoimentosAleatoriosResponseDTO>> BuscaDepoimentosAleatoriosAsync()
        {
            var randomDepoiments = new List<BuscaDepoimentosAleatoriosResponseDTO>();

            for (int i = 1; i <= 3; i++)
            {
                var depoimentsCounting = await _context.Depoimentos.CountAsync();
                var randomNumber = new Random().Next(0, depoimentsCounting);
                var query = await _context.Depoimentos.Where(x => x.Id == randomNumber).FirstOrDefaultAsync();
                var randomDepoimentMapping = _mapper.Map<Depoimento, BuscaDepoimentosAleatoriosResponseDTO>(query);
                randomDepoiments.Add(randomDepoimentMapping);
            }

            return randomDepoiments;
        }
    }
}
