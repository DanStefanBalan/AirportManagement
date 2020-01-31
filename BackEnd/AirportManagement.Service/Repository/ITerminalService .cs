using System;
using System.Collections.Generic;
using AirportManagement.Data;

namespace AirportManagement.Service.Repository
{
    public interface ITerminalService
    {
        IEnumerable<Terminal> GetTerminals();
        Terminal GetTerminal(Guid id);
        void InsertTerminal(Terminal terminal);
        void InsertTerminals(IEnumerable<Terminal> terminals);
        void DeleteTerminal(Guid id);
        void DeleteTerminals(IEnumerable<Terminal> terminals);
        void UpdateTerminal(Terminal terminal);
    }
}