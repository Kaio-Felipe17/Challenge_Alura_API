using API_Alura.Application.DTOs.Request;
using API_Alura.Application.DTOs.Response;
using API_Alura.Application.Models;

namespace API_Alura.Application.Profile
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            CreateMap<InsereDepoimentoRequestDTO, Depoimento>()
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => Convert.FromBase64String(src.Foto)));

            CreateMap<AtualizaDepoimentoRequestDTO, Depoimento>()
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => Convert.FromBase64String(src.Foto)));

            CreateMap<Depoimento, BuscaDepoimentosAleatoriosResponseDTO>()
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => Convert.ToBase64String(src.Foto)));

            CreateMap<InsereDestinoRequestDTO, Destino>()
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => Convert.FromBase64String(src.Foto)));

            CreateMap<AtualizaDestinoRequestDTO, Destino>()
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => Convert.FromBase64String(src.Foto)));
        }
    }
}
