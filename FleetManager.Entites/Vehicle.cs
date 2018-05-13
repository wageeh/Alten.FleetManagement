using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManager.Entities
{
    public class Vehicle:Entity
    {
        public string VIN { get; set; }

        public string RegistrationNumber { get; set; }

        public Guid OwnerId { get; set; }

        public virtual Client Owner { get; set; }
    }
}
