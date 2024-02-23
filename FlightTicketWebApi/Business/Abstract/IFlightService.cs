using FlightTicketWebApi.Models;
using FlightTicketWebApi.Utilities.Abstract;

namespace FlightTicketWebApi.Business.Abstract;

public interface IFlightService
{
    Task<IDataResult<OneWayFlightSearchModel>> OneWayFlightSearchAsync(FlightSearchModel model);
    Task<IDataResult<RoundTripFlightSearchModel>> RoundTripFlightSearchAsync(FlightSearchModel model);
}
