using FluentValidation;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Net;

namespace Application.Middlewares
{
    public class ExceptionMiddleware :IMiddleware
    {
        

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
            if (e.GetType() == typeof(ValidationException))
            {
                message = e.Message;
            }
            Log.Logger = new LoggerConfiguration()
                  .WriteTo.File("Logs", Serilog.Events.LogEventLevel.Error)
                 .CreateLogger();

            Log.Error(message);

            return httpContext.Response.WriteAsync(new 
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
