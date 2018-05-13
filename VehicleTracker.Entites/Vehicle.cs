
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleTracker.Entites
{
    // this is the same object as in Vehcile Entities, but redunadantly added her to follow microservice pattern
    public class Vehicle:Entity
    {
        public string RegistrationNumber { get; set; }
                
    }
}
