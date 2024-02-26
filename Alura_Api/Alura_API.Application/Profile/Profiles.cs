using Alura_API.Application.DTOs;
using Alura_API.Application.Models;

namespace Alura_API.Application.Profile
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
