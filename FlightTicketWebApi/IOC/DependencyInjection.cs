using FlightProvider;
using FlightTicketWebApi.Business.Abstract;
using FlightTicketWebApi.Business.Concrete;
using FlightTicketWebApi.Extensions;
using FlightTicketWebApi.Mapping;
using FlightTicketWebApi.Validation;
using FluentValidation.AspNetCore;

namespace FlightTicketWebApi.IOC
{
    public static class DependencyInjectionConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddHealthChecks().AddCheck<WcfServiceHealthCheckExtension>("WCFServiceHealthCheck", tags: new[] { "WCF" });
            services.AddControllers();
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<FlightSearchModelValidator>());
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(MapProfile));
            services.AddScoped<IFlightService, FlightManager>();
            services.AddScoped<IAirSearch, AirSearchClient>();
        }
    }
}
