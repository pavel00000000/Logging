using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Logging
{
    public class HeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HeaderMiddleware> _logger;

        public HeaderMiddleware(RequestDelegate next, ILogger<HeaderMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("X-Special-Header"))
            {
                var headerValue = context.Request.Headers["X-Special-Header"];
                if (headerValue != "ExpectedValue")
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    _logger.LogError("Значение заголовка X-Special-Header не соответствует ожидаемому значению");
                    return;
                }
                else
                {
                    _logger.LogInformation("Значение заголовка X-Special-Header соответствует ожидаемому значению");
                }
            }

            await _next(context);
        }

    }
}
