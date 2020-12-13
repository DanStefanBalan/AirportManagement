using AirportManagement.API.Models;
using AirportManagement.Data;
using AirportManagement.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.API.Controllers
{
    [Route("api/terminals")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        private readonly IRepository<Terminal> _terminalRepository;
        private readonly IMapper _mapper;

        public TerminalController(IRepository<Terminal> terminalRepository, IMapper mapper)
        {
            _terminalRepository = terminalRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateTerminal([FromBody] TerminalModel terminalModel)
        {
            var terminal = Terminal.Create(terminalModel.Name, 11);
            _terminalRepository.Add(terminal);
            return Ok();
        }
    }
}