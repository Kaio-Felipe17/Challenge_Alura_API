using Depoimentos_API.DTOs;
using Depoimentos_API.Models;

namespace Depoimentos_API.Profile
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<DepoimentosPostDTO, Depoimentos>();
        }
    }
}
