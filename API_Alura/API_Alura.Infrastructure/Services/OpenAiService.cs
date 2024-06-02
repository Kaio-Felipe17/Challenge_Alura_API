using API_Alura.Application.Exceptions;
using ChatGPT.Net;
using Microsoft.Extensions.Configuration;

namespace API_Alura.Infrastructure.Services
{
    public interface IOpenAiService
    {
        Task<string> CreateChatCompletion(string city);
    }
    public class OpenAiService : IOpenAiService
    {
        private readonly IConfiguration _configuration;

        public OpenAiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreateChatCompletion(string city)
        {

            var openAiKey = _configuration["OPENAI_API_KEY"] = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            if (openAiKey == null) throw new NotFoundException("Api Key não encontrada.");

            var openAi = new ChatGpt(openAiKey);

            var completion = await openAi
                .Ask(@$"Give a summary of {city}, emphasizing why this place is incredible. 
                    Use informal language and up to 100 characters maximum in each paragraph. 
                    Create 2 paragraphs in this summary. Translate to Brazilian Portuguese.");

            return completion;
        }
    }
}
