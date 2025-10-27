using System.Text.Json;
using Ardalis.Result;

namespace API.Extention
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly IHostEnvironment _host;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger,
                IHostEnvironment host)
        {
            _logger = logger;
            _host = host;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error occurred while processing the request Message:{ex.Message}, StackTrace:{ex.StackTrace}");
                var Message = Result.Error(_host.IsDevelopment() ? $"{ex?.InnerException?.Message}"
                    : "AnErrorOccurredPleaseContactSystemAdministrator");
                var serializedResponse = JsonSerializer.Serialize(Message);
                await context.Response.WriteAsync(serializedResponse);

            }
        }
    }
}
