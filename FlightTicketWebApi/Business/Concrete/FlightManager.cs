using AutoMapper;
using FlightProvider;
using FlightTicketWebApi.Business.Abstract;
using FlightTicketWebApi.Constants;
using FlightTicketWebApi.Models;
using FlightTicketWebApi.Utilities.Abstract;
using FlightTicketWebApi.Utilities.Concrete;

namespace FlightTicketWebApi.Business.Concrete;

public class FlightManager : IFlightService
{
    private readonly IAirSearch _airSearch;
    private readonly IMapper _mapper;
    public FlightManager(IAirSearch airSearch, IMapper mapper)
    {
        _airSearch = airSearch;
        _mapper = mapper;
    }

    public async Task<IDataResult<OneWayFlightSearchModel>> OneWayFlightSearchAsync(FlightSearchModel model)
    {
        var searchRequest = _mapper.Map<SearchRequest>(model);
        var departureFlights = await _airSearch.AvailabilitySearchAsync(searchRequest);

        if (departureFlights.HasError)
            return new ErrorDataResult<OneWayFlightSearchModel>(FlightMessages.ErrorMessage);

        var oneWayFlightSearchModel = _mapper.Map<OneWayFlightSearchModel>(departureFlights);
        return new SuccessDataResult<OneWayFlightSearchModel>(oneWayFlightSearchModel);
    }

    public async Task<IDataResult<RoundTripFlightSearchModel>> RoundTripFlightSearchAsync(FlightSearchModel model)
    {
        var departureFlights = await OneWayFlightSearchAsync(model);
        var returnFlights = await OneWayFlightSearchAsync(new FlightSearchModel
        {
            DepartureDate = model.ReturnDate,
            ReturnDate = model.DepartureDate,
            Destination = model.Origin,
            Origin = model.Destination
        });

        if (!departureFlights.Success || !returnFlights.Success)
            return new ErrorDataResult<RoundTripFlightSearchModel>(FlightMessages.ErrorMessage);

        return new SuccessDataResult<RoundTripFlightSearchModel>(new RoundTripFlightSearchModel
        {
            DepartureFlights = departureFlights?.Data?.DepartureFlights,
            ReturnFlights = returnFlights?.Data?.DepartureFlights
        });
    }
}
