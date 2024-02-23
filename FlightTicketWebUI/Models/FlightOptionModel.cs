using Newtonsoft.Json;

namespace FlightTicketWebUI.Models;

[JsonObject]
public class FlightOptionModel
{
    public string FlightNumber { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public DateTime ArrivalDateTime { get; set; }
    public decimal Price { get; set; }
    public string FlightDuration { get; set; }
}
