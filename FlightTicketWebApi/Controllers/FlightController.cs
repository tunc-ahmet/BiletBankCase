using FlightTicketWebApi.Business.Abstract;
using FlightTicketWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightTicketWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost]
        public async Task<IActionResult> RoundTripFlightSearch(FlightSearchModel model)
        {
            var searchResult = await _flightService.RoundTripFlightSearchAsync(model);
            return searchResult.Success ? Ok(searchResult) : BadRequest(searchResult);
        }
    }
}
