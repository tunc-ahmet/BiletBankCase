using FlightTicketWebApi.Utilities.Concrete;
using System.Net;

namespace FlightTicketWebApi.Extensions
{
    public class GlobalExceptionHandler
    {
        private RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";
            _logger.LogError(e.Message);

            //return httpContext.Response.WriteAsync(new ErrorResult($"{httpContext.Response.StatusCode} - {e.Message}").ToString());
            //Amaç dönüşlerde, hata mesajını tek tipe indirmek ve hata detayını göstermemek olduğu için e.message dönmedim.

            return httpContext.Response.WriteAsync(new ErrorResult($"{httpContext.Response.StatusCode} - Internal Server Error").ToString());
        }
    }
}
