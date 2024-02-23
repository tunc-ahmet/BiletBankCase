using FlightTicketWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightTicketWebUI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("SearchFlights")]
    public IActionResult SearchFlights(FlightSearchModel model)
    {
        return ViewComponent("FlightListComponent", model);
    }
}