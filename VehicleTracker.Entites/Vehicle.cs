
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleTracker.DTO
{
    // this is the same object as in Vehcile Entities, but redunadantly added her to follow microservice pattern
    public class Vehicle:BaseEntity
    {
        public string RegistrationNumber { get; set; }
                
    }
}
