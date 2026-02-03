using API.Models;
using Application.Exceptions;
using System.Net;
using System.Text.Json;
namespace API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
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
            string message;

            switch (exception)
            {
                case ValidationException ve:
                    status = HttpStatusCode.BadRequest;
                    message = ve.Message;
                    break;

                case KeyNotFoundException:
                    status = HttpStatusCode.NotFound;
                    message = "Resource not found";
                    break;

                case UnauthorizedAccessException:
                    status = HttpStatusCode.Unauthorized;
                    message = "Unauthorized";
                    break;
                case NotFoundException nf:
                    status = HttpStatusCode.NotFound;
                    message = nf.Message;
                    break;


                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "An unexpected error occurred";
                    break;
            }
            var errorResponse = new ErrorResponse
            {
                StatusCode = (int)status,
                Message = message,
                Details = exception.StackTrace 
            };

            var result = JsonSerializer.Serialize(errorResponse);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);

        }
    }
}
