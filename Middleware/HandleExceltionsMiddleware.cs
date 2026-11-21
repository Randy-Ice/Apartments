namespace Apartments.Middleware
{
    public class HandleExceltionsMiddleware
    {
        private readonly ILogger<HandleExceltionsMiddleware> _logger;
        private readonly RequestDelegate _next;
        public HandleExceltionsMiddleware(ILogger<HandleExceltionsMiddleware> logger,
            RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("An error occurred while processing your request.");
            }
        }

    }
}
