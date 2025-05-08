using Microsoft.AspNetCore.Http;
using Serilog;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Shared.Responses;



namespace BookingService.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = Log.Logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred.");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var result = JsonSerializer.Serialize(new { message = ex?.Message ?? "Internal Server Error" });
                await context.Response.WriteAsync(result);
            }
        }
    }
}