using FlightTicketWebUI.Business.Abstract;
using FlightTicketWebUI.Common;
using FlightTicketWebUI.Models;
using FlightTicketWebUI.Utilities.Abstract;
using FlightTicketWebUI.Utilities.Concrete;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FlightTicketWebUI.Business.Concrete
{
    public class FlightManager : IFlightService
    {
        private readonly IOptions<ApiUrl> _options;
        private readonly ApiUrl _apiUrl;
        public FlightManager(IOptions<ApiUrl> options)
        {
            _options = options;
            _apiUrl = _options.Value;
        }

        public async Task<IDataResult<RoundTripFlightSearchModel>> RoundTripFlightSearchAsync(FlightSearchModel model)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_apiUrl.BaseUrl);
            var response = await httpClient.PostAsJsonAsync(_apiUrl.RoundTripFlightSearchUrl, model);
            return JsonConvert.DeserializeObject<DataResult<RoundTripFlightSearchModel>>(await response.Content.ReadAsStringAsync())!;
        }
    }
}
