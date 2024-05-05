namespace Logging
{
    public class PostLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<PostLoggingMiddleware> _logger;

        public PostLoggingMiddleware(RequestDelegate next, ILogger<PostLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Post)
            {
                _logger.LogInformation("сработал POST запрос");
            }

            await _next(context);
        }
    }
}
