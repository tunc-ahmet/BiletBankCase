using FlightProvider;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FlightTicketWebApi.Extensions
{
    public class WcfServiceHealthCheckExtension : IHealthCheck
    {
        private readonly IAirSearch _airSearch;

        public WcfServiceHealthCheckExtension(IAirSearch airSearch)
        {
            _airSearch = airSearch;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var response = _airSearch.AvailabilitySearch(new SearchRequest());
            if (response == null)
                return HealthCheckResult.Unhealthy("WCF servisinde sorun tespit edildi.");

            return HealthCheckResult.Healthy("WCF servisi aktif.");
        }
    }
}
