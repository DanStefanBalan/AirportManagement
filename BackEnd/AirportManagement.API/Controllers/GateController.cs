using AirportManagement.Data;
using AirportManagement.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.API.Controllers
{
    [Route("api/gates")]
    [ApiController]
    public class GateController : ControllerBase
    {
        private readonly IRepository<Gate> _gateRepository;
        private readonly IMapper _mapper;

        public GateController(IRepository<Gate> gateRepository, IMapper mapper)
        {
            _gateRepository = gateRepository;
            _mapper = mapper;
        }
    }
}