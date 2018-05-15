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
        [HttpGet]
        public async Task<IEnumerable<StatusHistory>> Get()
        {
            return await _manager.GetLatestStatusHistory("", null, _context);
        }
        [HttpGet("{list}/{status}")]
        public async Task<IEnumerable<StatusHistory>> Get(string list, bool? status)
        {
            return await _manager.GetLatestStatusHistory(list, status, _context);
        }


    }
}
