using System;

namespace AirportManagement.Data
{
    public class Gate : BaseEntity
    {
        public Terminal Terminal { get; private set; }
        public Flight Flight { get; private set; }
        public Destination Destination { get; private set; }
        public Guid? FlightId { get; private set; }
        public Guid? DestinationId { get; private set; }
        public Guid? TerminalId { get; private set; }
        public int GateNumber { get; private set; }

        public Gate Create(int gateNumber, Terminal terminal) => new Gate()
        {
            Id = new Guid(),
            GateNumber = gateNumber,
            Terminal = terminal
        };
    }
}