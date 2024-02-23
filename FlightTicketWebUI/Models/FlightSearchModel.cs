namespace FlightTicketWebUI.Models;

public class FlightSearchModel
{
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ReturnDate { get; set; }
}
