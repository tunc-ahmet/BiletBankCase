using FlightTicketWebUI.Models;
using FlightTicketWebUI.Utilities.Abstract;

namespace FlightTicketWebUI.Business.Abstract;

public interface IFlightService
{
    Task<IDataResult<RoundTripFlightSearchModel>> RoundTripFlightSearchAsync(FlightSearchModel model);
}
