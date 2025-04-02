namespace eCommerce.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            // log exception and message
            _logger.LogError($"{ex.GetType()}: {ex.Message}");
            
            // log inner exception and inner exception message
            if (ex.InnerException is not null)
            {
                _logger.LogError($"{ex.InnerException?.GetType()}: {ex.InnerException?.Message}");
            }
            // return internal server error
            httpContext.Response.StatusCode = 500;
            
            //write error to response
            httpContext.Response.WriteAsJsonAsync(new { Message = ex.Message, Type = ex.GetType().ToString()});

        }
    }
}

public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}