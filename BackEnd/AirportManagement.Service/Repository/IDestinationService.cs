using System;
using System.Collections.Generic;
using AirportManagement.Data;

namespace AirportManagement.Service.Repository
{
    public interface IDestinationService
    {
        IEnumerable<Destination> GetDestinations();
        Destination GetDestination(Guid id);
        void InsertDestination(Destination destination);
        void InsertDestinations(IEnumerable<Destination> destinations);
        void DeleteDestination(Guid id);
        void DeleteDestinations(IEnumerable<Destination> destinations);
        void UpdateDestination(Destination destination);
    }
}