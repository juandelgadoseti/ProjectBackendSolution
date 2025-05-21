using APIProjectBackend.Exceptions;
using System.Net;
using System.Text.Json;

namespace APIProjectBackend.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unhandled exception: {ex.Message}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code = exception switch
            {
                NotFoundException => HttpStatusCode.NotFound,
                ValidationException => HttpStatusCode.BadRequest,
                UpdateConflictException => HttpStatusCode.Conflict,
                DeleteException => HttpStatusCode.Conflict,
                RepositoryException => HttpStatusCode.InternalServerError,
                _ => HttpStatusCode.InternalServerError
            };
            var result = JsonSerializer.Serialize(new
            {
                error = exception.Message,
                details = exception.InnerException?.Message
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
