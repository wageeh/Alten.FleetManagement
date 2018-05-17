using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManager.DTO;

namespace FleetManager.Repository
{
    public class FleetManagerContext : DbContext
    {
        public FleetManagerContext(DbContextOptions<FleetManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
