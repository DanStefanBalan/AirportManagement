using System;

namespace AirportManagement.Data
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
    }
}