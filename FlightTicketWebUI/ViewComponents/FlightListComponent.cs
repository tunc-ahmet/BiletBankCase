using FlightTicketWebUI.Business.Abstract;
using FlightTicketWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightTicketWebUI.ViewComponents
{
    public class FlightListComponent : ViewComponent
    {
        private readonly IFlightService _flightService;

        public FlightListComponent(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public async Task<IViewComponentResult> InvokeAsync(FlightSearchModel model)
        {
            var result = await _flightService.RoundTripFlightSearchAsync(model);
            return View(result);
        }
    }
}
