using Medical.Application.UseCase.Commons.Bases;
using Medical.Application.UseCase.Commons.Exceptions;
using Medical.Domain.Exceptions;
using System.Text.Json;

namespace Medical.Api.Extensions.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            var StatusCodeException = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            }; ;

            context.Response.ContentType = "application.json";
            context.Response.StatusCode = StatusCodeException;

            return context.Response.WriteAsync(new ErrorDetails
            {
                Message = exception.Message,
                StatusCodes = StatusCodeException,

            }.ToString());
            { }
        }

    }

    public class ErrorDetails
    {
        public int StatusCodes { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
