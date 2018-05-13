using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DbEntites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleTracker.API.Repository;
using VehicleTracker.Entites;

namespace VehicleTracker.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Tracker")]
    public class TrackerController : Controller
    {
        private readonly StatusContext _context;

        public TrackerController(StatusContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleStatus>> Get(List<string> vehiclelist, bool? vehiclestatus)
        {
            var predicate = PredicateBuilder.True<VehicleStatus>();
            if (vehiclelist.Count>0)
            {
                predicate = predicate.And(l => vehiclelist.Contains(l.Vehicle.RegistrationNumber));
            }
            if (vehiclestatus.HasValue)
            {
                predicate = predicate.And(l => l.Status == vehiclestatus.Value);
            }
            var vehicleStatus = await _context.VehicleStatus
                .Include(u => u.Vehicle)
                .Where(predicate)
                .OrderByDescending(s => s.CreatedDate)
                .ToListAsync();
            return vehicleStatus;
        }


    }
}
