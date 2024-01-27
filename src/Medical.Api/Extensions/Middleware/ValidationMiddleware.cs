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

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ValidationException exception)
            {
                context.Response.ContentType = "application.json";
                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                await context.Response.WriteAsJsonAsync(exception.Errors);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            var StatusCodeException = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            }; ;

         
            context.Response.StatusCode = StatusCodeException;

            await context.Response.WriteAsJsonAsync(new ErrorDetails
            {
                Message = exception.Message,
                StatusCode = StatusCodeException  
            });
        }

    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
      
    }
}
