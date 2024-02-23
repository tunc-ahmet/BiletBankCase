namespace FlightTicketWebUI.Models
{
    public class RoundTripFlightSearchModel : OneWayFlightSearchModel
    {
        public List<FlightOptionModel>? ReturnFlights { get; set; }
    }
}
