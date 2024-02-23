using AutoMapper;
using FlightProvider;
using FlightTicketWebApi.Models;

namespace FlightTicketWebApi.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<FlightSearchModel, SearchRequest>();
            CreateMap<FlightOption, FlightOptionModel>();
            CreateMap<SearchResult, OneWayFlightSearchModel>()
                .ForMember(x => x.DepartureFlights, opt => opt.MapFrom(x => x.FlightOptions));
        }
    }
}
