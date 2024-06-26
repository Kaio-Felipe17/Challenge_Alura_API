﻿using API_Alura.Application.DTOs.Request;
using API_Alura.Application.Exceptions;
using API_Alura.Application.Models;
using API_Alura.Infrastructure.Context;
using API_Alura.Infrastructure.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Alura.Core.Repository
{
    public interface IDestinosRepository
    {
        Task<Destino> InsereDestinoAsync(InsereDestinoRequestDTO dto);
        Task<Destino?> ConsultaDestinoAsync(string nome);
        Task<Destino> ConsultaDestinoV2Async(int id);
        Task<Destino> AtualizaDestinoAsync(AtualizaDestinoRequestDTO dto);
        Task<bool> DeletaDestinoAsync(int id);
    }
    public class DestinosRepository : IDestinosRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IOpenAiService _openAiService;

        public DestinosRepository(
            DatabaseContext context, 
            IMapper mapper,
            IOpenAiService openAiService)
        {
            _mapper = mapper;   
            _context = context;
            _openAiService = openAiService;
        }

        public async Task<Destino> InsereDestinoAsync(InsereDestinoRequestDTO dto)
        {
            var destinoMap = _mapper.Map<InsereDestinoRequestDTO, Destino>(dto);

            if (string.IsNullOrEmpty(destinoMap.TextoDescritivo))
            {
                destinoMap.TextoDescritivo = await _openAiService.CreateChatCompletion(destinoMap.Nome);
            }

            _context.Destinos.Add(destinoMap);
            await _context.SaveChangesAsync();

            return destinoMap;
        }

        public async Task<Destino?> ConsultaDestinoAsync(string nome)
        {
            var destino = await _context.Destinos.Where(x => x.Nome == nome).FirstOrDefaultAsync();

            if (destino == default) throw new NotFoundException("Nenhum destino foi encontrado.");

            return destino;
        }

        public async Task<Destino> ConsultaDestinoV2Async(int id)
        {
            var buscaDestino = await _context.Destinos.FirstOrDefaultAsync(x => x.Id == id);

            if (buscaDestino == default) throw new NotFoundException("Nenehum destino foi encontrado");

            return buscaDestino;
        }

        public async Task<Destino> AtualizaDestinoAsync(AtualizaDestinoRequestDTO dto)
        {
            var destiny = await _context.Destinos.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();

            if (destiny == default) throw new NotFoundException($"Id {dto.Id} inexistente.");

            _mapper.Map(dto, destiny);
            await _context.SaveChangesAsync();

            return destiny;
        }

        public async Task<bool> DeletaDestinoAsync(int id)
        {
            var destiny = await _context.Destinos.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (destiny == default) throw new NotFoundException($"Id {id} inexistente.");

            _context.Destinos.Remove(destiny);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
