using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleTracker.DTO;

namespace VehicleTracker.Repository
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options)
            : base(options)
        {
        }
        public DbSet<VehicleStatus> VehicleStatus { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
