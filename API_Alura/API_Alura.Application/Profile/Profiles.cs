using API_Alura.Application.DTOs;
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

            CreateMap<DepoimentosPutDTO, Depoimentos>();
        }
    }
}
