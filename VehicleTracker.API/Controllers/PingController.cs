using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTracker.API.BL;
using VehicleTracker.API.Repository;
using VehicleTracker.Entites;

namespace VehicleTracker.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Ping")]
    public class PingController : Controller
    {
        private readonly StatusContext _context;

        public PingController(StatusContext context)
        {
            _context = context;
        }
        // GET: api/Ping
        [HttpGet]
        public async Task<List<VehicleStatus>> Get()
        {
            string s = Startup.botURL;
            PingManager manager = new PingManager(_context, Startup.botURL);
            List<VehicleStatus> lst = await manager.UpdateVehicleStatusesAsync();
            return lst;
        }

        // GET: api/Ping/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Ping
        [HttpPost]
        public async void Post()
        {
            PingManager manager = new PingManager(_context, Startup.botURL);
            await manager.UpdateVehicleStatusesAsync();
        }
        
        
    }
}
