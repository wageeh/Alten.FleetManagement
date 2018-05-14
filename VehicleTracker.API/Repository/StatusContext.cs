using Microsoft.EntityFrameworkCore;
using VehicleTracker.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.API.Repository
{
    public class StatusContext : DbContext
    {
        public StatusContext(DbContextOptions<StatusContext> options)
            : base(options)
        {
        }

        public DbSet<VehicleStatus> VehicleStatus { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
