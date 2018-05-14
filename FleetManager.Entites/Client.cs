using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManager.DTO
{
    public class Client:Entity
    {
        public string Name { get; set; }
        public string Adress { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
