using System;
using System.Collections.Generic;
using AirportManagement.Data;

namespace AirportManagement.Service.Repository
{
    public interface IGateService
    {
        IEnumerable<Gate> GetGates();
        Gate GetGate(Guid id);
        void InsertGate(Gate gate);
        void InsertGates(IEnumerable<Gate> gates);
        void DeleteGate(Guid id);
        void DeleteGates(IEnumerable<Gate> gates);
        void UpdateGate(Gate gate);
    }
}