using Depoimentos_API.DTOs;
using Depoimentos_API.Models;

namespace Depoimentos_API.Profile
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
