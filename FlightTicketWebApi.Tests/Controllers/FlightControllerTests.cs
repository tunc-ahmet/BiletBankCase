using FlightTicketWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace FlightTicketWebApi.Tests.Controllers
{
    public class FlightControllerTests
    {
        private readonly Mock<IFlightService> _mockFlightService;
        private readonly FlightController _controller;

        public FlightControllerTests()
        {
            _mockFlightService = new Mock<IFlightService>();
            _controller = new FlightController(_mockFlightService.Object);
        }

        [Fact]
        public async Task RoundTripFlightSearch_ValidModel_ReturnsOkResult()
        {
            // Arrange
            var model = new FlightSearchModel { };
            var resultToReturn = new SuccessDataResult<RoundTripFlightSearchModel>();
            _mockFlightService.Setup(s => s.RoundTripFlightSearchAsync(It.IsAny<FlightSearchModel>())).ReturnsAsync(resultToReturn);

            // Act
            var result = await _controller.RoundTripFlightSearch(model);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}