using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;


namespace Logging
{
    public class GetLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GetLoggingMiddleware> _logger;

        public GetLoggingMiddleware(RequestDelegate next, ILogger<GetLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get)
            {
                _logger.LogInformation("сработал GET запрос");
            }

            await _next(context);
        }
    }
}
