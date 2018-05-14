using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTracker.API.BL;
using VehicleTracker.API.Repository;
using VehicleTracker.BusinessModel;

namespace VehicleTracker.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Tracker")]
    public class TrackerController : Controller
    {
        private readonly StatusContext _context;
        private StatusManager _manager;

        public TrackerController(StatusContext context)
        {
            _context = context;
            _manager = new StatusManager();
        }

        public async Task<IEnumerable<StatusHistory>> Get([FromBody]List<string> vehiclelist, bool? vehiclestatus)
        {
            return await _manager.GetLatestStatusHistory(vehiclelist, vehiclestatus, _context);
        }


    }
}
