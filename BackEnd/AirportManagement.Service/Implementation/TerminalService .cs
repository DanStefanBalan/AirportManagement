using System;
using System.Collections.Generic;
using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;

namespace AirportManagement.Service.Implementation
{
    public class TerminalService : ITerminalService
    {
        private readonly IRepository<Terminal> _terminalRepository;

        public TerminalService(IRepository<Terminal> terminalRepository)
        {
            _terminalRepository = terminalRepository;
        }

        public void InsertTerminals(IEnumerable<Terminal> terminals)
        {
            _terminalRepository.InsertRange(terminals);
        }

        public void DeleteTerminal(Guid id)
        {
            var terminal = _terminalRepository.Get(id);
            if (terminal != null)
            {
                _terminalRepository.Delete(terminal);
                _terminalRepository.SaveChanges();
            }
        }

        public void DeleteTerminals(IEnumerable<Terminal> terminals)
        {
            _terminalRepository.DeleteRange(terminals);
        }

        public Terminal GetTerminal(Guid id)
        {
            return _terminalRepository.Get(id);
        }

        public IEnumerable<Terminal> GetTerminals()
        {
            return _terminalRepository.GetAll();
        }

        public void InsertTerminal(Terminal terminal)
        {
            _terminalRepository.Insert(terminal);
        }

        public void UpdateTerminal(Terminal terminal)
        {
            _terminalRepository.Update(terminal);
        }

    }
}