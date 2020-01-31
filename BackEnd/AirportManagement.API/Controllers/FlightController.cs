using AirportManagement.Data;
using AirportManagement.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.API.Controllers
{
    [Route("api/flights")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IRepository<Flight> _flightRepository;
        private readonly IMapper _mapper;

        public FlightController(IRepository<Flight> flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }
    }
}