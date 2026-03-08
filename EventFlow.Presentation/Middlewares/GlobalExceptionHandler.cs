using EventFlow.Business.Abstraction;
using EventFlow.Business.Dtos;

namespace EventFlow.Presentation.Middlewares;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;
    public GlobalExceptionHandler(RequestDelegate next)
    {
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
            ResultDto errorResult = new()
            {
                IsSuccess = false,
                Message = "Internal Server Eerror",
                StatusCode = 500
            };

            if (ex is IBaseException baseException)
            {
                errorResult.Message = ex.Message;
                errorResult.StatusCode = baseException.StatusCode;
            }

            context.Response.StatusCode = errorResult.StatusCode;

            await context.Response.WriteAsJsonAsync(errorResult);
        }
    }
}
