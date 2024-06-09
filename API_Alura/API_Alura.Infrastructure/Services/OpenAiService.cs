using API_Alura.Application.Exceptions;
using dotenv.net;
using OpenAI_API;
using OpenAI_API.Completions;

namespace API_Alura.Infrastructure.Services
{
    public interface IOpenAiService
    {
        Task<string> CreateChatCompletion(string city);
    }
    public class OpenAiService : IOpenAiService
    {
        public async Task<string> CreateChatCompletion(string city)
        {
            DotEnv.Load();

            var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            if (apiKey == null) throw new NotFoundException("Api Key não encontrada.");

            var openAi = new OpenAIAPI(apiKey);

            var result = await openAi.Completions.CreateCompletionAsync(new CompletionRequest
            {
                Prompt = @$"Dê um resumo de {city}, enfatizando por que este lugar é incrível. 
                            Use linguagem informal e até 100 caracteres no máximo em cada parágrafo. 
                            Crie 2 parágrafos neste resumo.",
                MaxTokens = 200
            });

            return result.Completions[0].Text.Trim();
        }
    }
}
