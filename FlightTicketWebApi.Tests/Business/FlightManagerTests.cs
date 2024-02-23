using AutoMapper;
using FlightProvider;
using FlightTicketWebApi.Business.Concrete;

namespace FlightTicketWebApi.Tests.Business
{
    public class FlightManagerTests
    {
        private readonly Mock<IAirSearch> _mockAirSearch;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IFlightService _manager;

        public FlightManagerTests()
        {
            _mockAirSearch = new Mock<IAirSearch>();
            _mockMapper = new Mock<IMapper>();
            _manager = new FlightManager(_mockAirSearch.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task OneWayFlightSearchAsync_ValidModel_ReturnsSuccessResult()
        {
            // Arrange
            var flightSearchModel = new FlightSearchModel { };
            var searchRequest = new SearchRequest { };
            var departureFlights = new SearchResult { };

            _mockMapper.Setup(m => m.Map<SearchRequest>(It.IsAny<FlightSearchModel>())).Returns(searchRequest);
            _mockAirSearch.Setup(a => a.AvailabilitySearchAsync(searchRequest)).ReturnsAsync(departureFlights);

            // Act
            var result = await _manager.OneWayFlightSearchAsync(flightSearchModel);

            // Assert
            Assert.True(result.Success);
            Assert.IsType<SuccessDataResult<OneWayFlightSearchModel>>(result);
        }

        [Fact]
        public async Task RoundTripFlightSearchAsync_ValidModel_ReturnsSuccessResult()
        {
            // Arrange
            var flightSearchModel = new FlightSearchModel { };
            var oneWayResult = new SuccessDataResult<OneWayFlightSearchModel>(new OneWayFlightSearchModel { });

            _mockMapper.Setup(m => m.Map<OneWayFlightSearchModel>(It.IsAny<SearchResult>())).Returns(oneWayResult.Data);
            _mockAirSearch.Setup(a => a.AvailabilitySearchAsync(It.IsAny<SearchRequest>())).ReturnsAsync(new SearchResult { });

            // Act
            var result = await _manager.RoundTripFlightSearchAsync(flightSearchModel);

            // Assert
            Assert.True(result.Success);
            Assert.IsType<SuccessDataResult<RoundTripFlightSearchModel>>(result);
        }
    }
}
