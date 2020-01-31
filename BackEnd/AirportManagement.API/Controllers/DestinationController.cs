using AirportManagement.Data;
using AirportManagement.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.API.Controllers
{
    [Route("api/destinations")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IRepository<Destination> _destinationRepository;
        private readonly IMapper _mapper;

        public DestinationController(IRepository<Destination> destinationRepository, IMapper mapper)
        {
            _destinationRepository = destinationRepository;
            _mapper = mapper;
        }
    }
}