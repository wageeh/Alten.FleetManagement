using System.Collections.Generic;
using System.Threading.Tasks;
using Core.BaseRepository;
using Microsoft.AspNetCore.Mvc;
using VehicleTracker.API.BL;
using VehicleTracker.DTO;

namespace VehicleTracker.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Ping")]
    public class PingController : Controller
    {
        private readonly IBaseRepository<Vehicle> _vehiclerepository;
        private readonly IBaseRepository<VehicleStatus> _statusrepository;

        public PingController(IBaseRepository<Vehicle> vehiclerepository, IBaseRepository<VehicleStatus> statusrepository)
        {
            _vehiclerepository = vehiclerepository;
            _statusrepository = statusrepository;
        }
        // GET: api/Ping
        [HttpGet]
        public async Task<List<VehicleStatus>> Get()
        {
            string s = Startup.botURL;
            PingManager manager = new PingManager(_vehiclerepository, Startup.botURL);
            List<Vehicle> vehicles = await new VehicleManager(_vehiclerepository).GetAllVehicles();
            List<VehicleStatus> vehiclestatuslst = await manager.GetVehicleStatusesAsync(vehicles);
            _statusrepository.InsertRange(vehiclestatuslst);
            return vehiclestatuslst;
        }

        // GET: api/Ping/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }       
        
    }
}
