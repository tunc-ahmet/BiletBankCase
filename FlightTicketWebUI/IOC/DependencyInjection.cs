using FlightTicketWebUI.Business.Abstract;
using FlightTicketWebUI.Business.Concrete;
using FlightTicketWebUI.Common;

namespace FlightTicketWebUI.IOC;

public static class DependencyInjectionConfiguration
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews().AddRazorRuntimeCompilation();
        services.Configure<ApiUrl>(configuration.GetSection(nameof(ApiUrl)));
        services.AddScoped<IFlightService, FlightManager>();
        services.AddHttpClient();
    }
}
