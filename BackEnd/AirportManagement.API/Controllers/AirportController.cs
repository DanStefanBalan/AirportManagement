using System;
using System.Collections.Generic;
using System.Linq;
using AirportManagement.API.Models;
using AirportManagement.Data;
using AirportManagement.Service.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.API.Controllers
{
    [Route("api/airports")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _airportService;
        private readonly IMapper _mapper;

        public AirportController(IAirportService airportService, IMapper mapper )
        {
            _airportService = airportService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateAirport([FromBody] AirportModel airportModel)
        {
            var airport = Airport.Create(airportModel.Name, airportModel.Country, airportModel.City);
            var duplicateAirport =
                _airportService.GetSameAirport(airportModel.Name, airportModel.Country, airportModel.City);
            if(!duplicateAirport.Any() )
            {
                _airportService.Add(airport);
                return Ok("all good");
            }
            else
            {
                return BadRequest("test");
            }
        }

        [HttpGet]
        public ActionResult <IEnumerable<AirportModel>> GetAllAirports ()
        {
            var airports = _airportService.GetAll();
            return Ok(_mapper.Map<IEnumerable<AirportModel>>(airports));
        }

        [HttpGet("{airportId}")]
        public ActionResult GetAirportById(Guid airportId)
        {
            var airport = _airportService.Get(airportId);
            return Ok(_mapper.Map<AirportModel>(airport));
        }



        [HttpDelete("{airportId}")]
        public ActionResult DeleteAirport(Guid airportId)
        {
            var airport = _airportService.Get(airportId);
            if (airport == null)
            {
                return NotFound();
            }

            _airportService.Remove(airport);
            return NoContent();
        }

        [HttpPut("{airportId}")]
        public IActionResult UpdateAirportDetails(Guid airportId, [FromBody] AirportModel airportModel)
        {
            var airport = _airportService.Get(airportId);
            airport.Update(airportModel.Name, airportModel.Country, airportModel.City);
            _airportService.Update(airport);
            return Ok();
        }
    }
}