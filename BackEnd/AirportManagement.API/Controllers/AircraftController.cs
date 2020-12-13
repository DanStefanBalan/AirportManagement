using System;
using System.Collections.Generic;
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
        public ActionResult CreateAircraft([FromBody] AircraftModel aircraftModel)
        {
            var aircraft = Aircraft.Create(aircraftModel.AircraftNumber, aircraftModel.CountryOfRegistration, aircraftModel.NumberOfPilots, aircraftModel.Manufacturer, aircraftModel.Model, aircraftModel.NumberOfSeats, aircraftModel.NumberOfFlightAttendants);
            _aircraftService.Add(aircraft);
            return Ok("all good");
        }

        [HttpGet]
        public ActionResult<IEnumerable<AircraftModel>> GetAllAircrafts()
        {  
            var aircrafts = _aircraftService.GetAll();
            return Ok(_mapper.Map<IEnumerable<AircraftModel>>(aircrafts));
        }

        [HttpGet("{aircraftId}")]
        public ActionResult GetAircraftById(Guid aircraftId)
        {
            var aircraft = _aircraftService.Get(aircraftId);
            return Ok(_mapper.Map<AircraftModel>(aircraft));
        }

        [HttpDelete("{aircraftId}")]
        public ActionResult DeleteAircraft(Guid aircraftId)
        {
            var aircraft = _aircraftService.Get(aircraftId);
            if (aircraft == null)
            {
                return NotFound();
            }

            _aircraftService.Remove(aircraft);
            return NoContent();
        }

        [HttpPut("{aircraftId}")]
        public IActionResult UpdateAircraftDetails(Guid aircraftId, [FromBody] AircraftModel aircraftModel)
        {
            var aircraft = _aircraftService.Get(aircraftId);
            aircraft.Update(aircraftModel.AircraftNumber, aircraftModel.CountryOfRegistration, aircraftModel.NumberOfPilots, aircraftModel.Manufacturer, aircraftModel.Model, aircraftModel.NumberOfSeats, aircraftModel.NumberOfFlightAttendants);
            _aircraftService.Update(aircraft);
            return Ok();
        }

        [HttpGet("aicraftNumbers")]
        public IActionResult GetAircraftsNumber()
        {
            var aicraftNumbers = _aircraftService.GetAircraftsNumber();
            return Ok(aicraftNumbers);
        }
    }
}