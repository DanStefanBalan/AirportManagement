using AirportManagement.API.Models;
using AirportManagement.Data;
using AutoMapper;

namespace AirportManagement.API
{
    public class MapingEntities : Profile
    {
        public MapingEntities()
        {
            CreateMap<Airport, AirportModel>().ReverseMap();
            CreateMap<Aircraft, AircraftModel>().ReverseMap();
            CreateMap<Destination, DestinationModel>().ReverseMap();
            CreateMap<Flight, FlightModel>().ReverseMap();
            CreateMap<Gate, GateModel>().ReverseMap();
            CreateMap<Terminal, TerminalModel>().ReverseMap();
        }
    }
}
