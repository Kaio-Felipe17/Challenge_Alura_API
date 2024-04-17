using Microsoft.AspNetCore.Mvc;

namespace API_Alura.Controllers
{
    [ApiController]
    [Route("destinos")]
    public class DestinosController : ControllerBase
    {
        public DestinosController()
        {
            
        }

        [HttpPost("inserirDestino")]
        public async Task PostDestinos()
        {

        }
    }
}
