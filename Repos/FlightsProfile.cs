using AutoMapper;

namespace FlightDataApi.Repos
{
    public class FlightsProfile :Profile
    {
        public FlightsProfile()
        {
            CreateMap<Models.Flight, Models.FlightDto>().ReverseMap();
        }
    }
}
