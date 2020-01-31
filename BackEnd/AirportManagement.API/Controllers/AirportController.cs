using System;
using System.Collections.Generic;
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
            _airportService.InsertAirport(airport);
            return Ok("all good");
        }

        [HttpGet]
        public ActionResult <IEnumerable<AirportModel>> GetAllAirports ()
        {
            var airports = _airportService.GetAirports();
            return Ok(_mapper.Map<IEnumerable<AirportModel>>(airports));
        }

        [HttpGet("{airportId}")]
        public ActionResult GetAirportById(Guid airportId)
        {
            var airport = _airportService.GetAirport(airportId);
            return Ok(_mapper.Map<AirportModel>(airport));
        }



        [HttpDelete("{airportId}")]
        public ActionResult DeleteAirport(Guid airportId)
        {
            var airportFromDb = _airportService.GetAirport(airportId);
            if (airportFromDb == null)
            {
                return NotFound();
            }

            _airportService.DeleteAirport(airportId);
            return NoContent();
        }
    }
}