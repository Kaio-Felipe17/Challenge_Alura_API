using API_Alura.Application.Exceptions;
using System.Text.Json;

namespace API_Alura.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case NotFoundException notFound:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        await WriteExceptionReturn(response, notFound.Message);
                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        await WriteExceptionReturn(response, "Ocorreu um erro ao processar a solicitação.");
                        break;
                }
            }
        }

        private async Task WriteExceptionReturn(HttpResponse response, string message)
        {
            var messageSerialized = JsonSerializer.Serialize(new { mensagem = message });
            await response.WriteAsync(messageSerialized);
        }
    }
}
