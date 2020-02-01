using AirportManagement.API.Models;
using AirportManagement.Data;
using AirportManagement.Service.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.API.Controllers
{
    [Route("api/aircrafts")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly IAircraftService _aircraftService;
        private readonly IMapper _mapper;

        public AircraftController(IAircraftService aircraftService, IMapper mapper )
        {
            _aircraftService = aircraftService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateAirport([FromBody] AircraftModel aircraftModel)
        {
            var aircraft = Aircraft.Create(aircraftModel.AircraftType, aircraftModel.CountryOfRegistration, aircraftModel.NumberOfPilots, aircraftModel.Manufacturer, aircraftModel.Model, aircraftModel.NumberOfSeats, aircraftModel.NumberOfFlightAttendants);
            _aircraftService.Add(aircraft);
            return Ok("all good");
        }

    }
}