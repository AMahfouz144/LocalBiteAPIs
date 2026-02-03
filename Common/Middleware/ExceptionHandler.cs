using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions.Middleware
{ 
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
        public ExceptionHandler(RequestDelegate next) => this.next = next;
     
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            List<string> messages = new List<string>();
            context.Response.ContentType = "application/json";
            ExceptionType type = ExceptionType.General;

            if (ex is AppException)
            {
                var exception = ex as AppException;
                context.Response.StatusCode = exception.StatusCode;
                if (exception is AppAuthException && (exception as AppAuthException).AuthExceptionType == AuthExceptionType.NotAvailable)
                    context.Response.StatusCode = 401;

                if (exception is AppValidationException)
                {
                    var invalidData = (exception as AppValidationException).ValidationResult;
                    if (invalidData != null)
                        messages = new List<string>() { invalidData.ToString() };
                    else
                        messages = new List<string>() { exception.ClientMessage };
                }
                else
                    messages = new List<string>() { exception.ClientMessage };

                type = exception.Type;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                messages = new List<string>() { $"Internal Server Error.", ex.Message };
            }

           // var logger = context.RequestServices.GetService(typeof(IVLogger)) as IVLogger;

            string description = GetRequestDescription(context);

            //logger.Error(ex.Message, messages.FirstOrDefault(), ex.StackTrace, description, (int)type);
            var result = (new { Result = messages }).Serialize();
            return context.Response.WriteAsync(result);
        }

        private string GetRequestDescription(HttpContext context)
        {
            var request = context.Request;
            string api = context.Request.Path;
            string bodyAsText = null;
            string userId = context.User?.Claims?.FirstOrDefault(obj => obj.Type == "UserId")?.Value;
            string token = context.Request.Headers["Authorization"];

            using (var reader = new StreamReader(request.Body, true))
            {
                var tsk = reader.ReadToEndAsync();
                while (!tsk.IsCompleted) { };
                bodyAsText = tsk.Result;
            }

            StringBuilder builder = new StringBuilder($"API: {api}\n");

            if (!string.IsNullOrWhiteSpace(userId))
                builder.AppendLine($"UserId: {userId}");

            if (!string.IsNullOrWhiteSpace(token))
                builder.AppendLine($"Token: {token}");

            if (!string.IsNullOrWhiteSpace(bodyAsText))
                builder.AppendLine($"Body: { bodyAsText}");

            return builder.ToString(); ;
        }
    }
}