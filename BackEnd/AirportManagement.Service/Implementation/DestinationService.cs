using System;
using System.Collections.Generic;
using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;

namespace AirportManagement.Service.Implementation
{
    public class DestinationService : IDestinationService
    {
        private readonly IRepository<Destination> _destinationRepository;

        public DestinationService(IRepository<Destination> destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public void InsertDestinations(IEnumerable<Destination> destinations)
        {
            _destinationRepository.InsertRange(destinations);
        }

        public void DeleteDestination(Guid id)
        {
            var destination = _destinationRepository.Get(id);
            if (destination != null)
            {
                _destinationRepository.Delete(destination);
                _destinationRepository.SaveChanges();
            }
        }

        public void DeleteDestinations(IEnumerable<Destination> destinations)
        {
            _destinationRepository.DeleteRange(destinations);
        }

        public Destination GetDestination(Guid id)
        {
            return _destinationRepository.Get(id);
        }

        public IEnumerable<Destination> GetDestinations()
        {
            return _destinationRepository.GetAll();
        }

        public void InsertDestination(Destination destination)
        {
            _destinationRepository.Insert(destination);
        }

        public void UpdateDestination(Destination destination)
        {
            _destinationRepository.Update(destination);
        }
    }
}