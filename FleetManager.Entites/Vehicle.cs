using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManager.DTO
{
    public class Vehicle:BaseEntity
    {
        public string VIN { get; set; }

        public string RegistrationNumber { get; set; }

        public Guid OwnerId { get; set; }

        public virtual Client Owner { get; set; }
    }
}
