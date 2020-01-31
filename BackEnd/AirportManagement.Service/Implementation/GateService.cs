using System;
using System.Collections.Generic;
using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;

namespace AirportManagement.Service.Implementation
{
    public class GateService : IGateService
    {
        private readonly IRepository<Gate> _gateRepository;

        public GateService(IRepository<Gate> gateRepository)
        {
            _gateRepository = gateRepository;
        }

        public void InsertGates(IEnumerable<Gate> gates)
        {
            _gateRepository.InsertRange(gates);
        }

        public void DeleteGate(Guid id)
        {
            var gate = _gateRepository.Get(id);
            if (gate != null)
            {
                _gateRepository.Delete(gate);
                _gateRepository.SaveChanges();
            }
        }

        public void DeleteGates(IEnumerable<Gate> gates)
        {
            _gateRepository.DeleteRange(gates);
        }

        public void InsertGate(Gate gate)
        {
            _gateRepository.Insert(gate);
        }

        public Gate GetGate(Guid id)
        {
            return _gateRepository.Get(id);
        }

        public IEnumerable<Gate> GetGates()
        {
            return _gateRepository.GetAll();
        }

        public void UpdateGate(Gate gate)
        {
            _gateRepository.Update(gate);
        }
    }
}