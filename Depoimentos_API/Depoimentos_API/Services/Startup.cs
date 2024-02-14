using Depoimentos_API.Repository;

namespace Depoimentos_API.Services
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<IDepoimentosRepository, DepoimentosRepository>();
        }
    }
}
