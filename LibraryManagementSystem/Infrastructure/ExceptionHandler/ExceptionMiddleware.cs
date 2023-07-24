using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Text.Json;

namespace LibraryManagementSystem.Infrastructure.ExceptionHandler;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status;
        string stackTrace;
        string message;
        var exceptionType = exception.GetType();
        if (exceptionType == typeof(BadRequestException))
        {
            message = exception.Message;
            status = HttpStatusCode.BadRequest;
            stackTrace = exception.StackTrace ?? string.Empty;
        }
        else if (exceptionType == typeof(NotFoundException))
        {
            message = exception.Message;
            status = HttpStatusCode.NotFound;
            stackTrace = exception.StackTrace ?? string.Empty;
        }
        else if(exceptionType == typeof(AuthenticationErrorException))
        {
            message = exception.Message;
            status = HttpStatusCode.Unauthorized;
            stackTrace = exception.StackTrace ?? String.Empty;
        }
        else
        {
            status = HttpStatusCode.InternalServerError;
            message = exception.Message;
            stackTrace = exception.StackTrace ?? string.Empty;
        }
        var exceptionResult = JsonSerializer.Serialize(new
        {
            error = message,
            stackTrace
        });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;
        return context.Response.WriteAsync(exceptionResult);
    }
}


