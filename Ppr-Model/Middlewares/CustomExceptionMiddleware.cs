using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net;
using Ppr_Model.Services;

namespace Ppr_Model.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILoggerService _loggerService;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                _loggerService.Write(message);

                await _next(context);
                watch.Stop();

                message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path + " responsed " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms.";
                _loggerService.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
        }
        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error] HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message: " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds;
            _loggerService.Write(message);


            var res = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);

            return context.Response.WriteAsync(res);
        }
    }


    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}