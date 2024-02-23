using FlightTicketWebApi.Extensions;
using FlightTicketWebApi.IOC;
using FlightTicketWebApi.Middleware;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
DependencyInjectionConfiguration.Configure(builder.Services);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandler>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<SecurityHeadersMiddleware>();

app.Use(async (context, next) => //Güvenlik açýklarý için eklendi
{
    context.Response.Headers.Add("Content-Security-Policy", "script-src 'self';");
    await next();
});

app.MapHealthChecks("/health", new HealthCheckOptions //WCF servisi için healthcheck eklendi
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var response = new
        {
            status = report.Status.ToString(),
            checks = report.Entries.Select(x => new
            {
                name = x.Key,
                status = x.Value.Status.ToString(),
                exception = x.Value.Exception?.Message ?? "Hata bulunamadý",
                duration = x.Value.Duration.ToString()
            })
        };
        await context.Response.WriteAsJsonAsync(response);
    }
}); 

app.Run();
