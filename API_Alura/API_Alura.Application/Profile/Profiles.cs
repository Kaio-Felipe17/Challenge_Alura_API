using API_Alura.Application.DTOs;
using API_Alura.Application.Models;

namespace API_Alura.Application.Profile
{
    public class Profiles : AutoMapper.Profile
    {
        public Profiles()
        {
            CreateMap<DepoimentosPostDTO, Depoimentos>();
            CreateMap<DepoimentosPutDTO, Depoimentos>();
        }
    }
}
