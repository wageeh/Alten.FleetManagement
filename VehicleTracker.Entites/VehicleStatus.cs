using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleTracker.DTO
{
    public class VehicleStatus: BaseEntity
    {
        public bool Status { get; set; }

        public Guid VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
