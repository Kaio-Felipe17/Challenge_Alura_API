using API_Alura.Application.DTOs.Request;
using API_Alura.Application.DTOs.Response;
using API_Alura.Application.Models;
using AutoMapper;

namespace API_Alura.Application.Profile
{
    public class Profiles : AutoMapper.Profile
    {
        public Profiles()
        {
            CreateMap<DepoimentosPostDTO, Depoimentos>()
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => Convert.FromBase64String(src.Foto)));

            CreateMap<DepoimentosPutDTO, Depoimentos>()
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => Convert.FromBase64String(src.Foto)));

            CreateMap<Depoimentos, DepoimentosAleatoriosGetDTO>()
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => Convert.ToBase64String(src.Foto)));

            CreateMap<DestinosPostDTO, Destinos>()
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => Convert.FromBase64String(src.Foto)));
        }
    }
}
