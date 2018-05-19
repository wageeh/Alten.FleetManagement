using System.Collections.Generic;
using System.Threading.Tasks;
using Core.BaseRepository;
using Microsoft.AspNetCore.Mvc;
using VehicleTracker.API.BL;
using VehicleTracker.BusinessModel;
using VehicleTracker.DTO;

namespace VehicleTracker.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Tracker")]
    public class TrackerController : Controller
    {
        private readonly IBaseRepository<VehicleStatus> _repository;
        private StatusManager _manager;

        public TrackerController(IBaseRepository<VehicleStatus> repository)
        {
            _repository = repository;
            _manager = new StatusManager(_repository);
        }
        [HttpGet]
        public async Task<IEnumerable<StatusHistory>> Get()
        {
            return await _manager.GetLatestStatusHistory("", null);
        }
        [HttpGet("{list}/{status}")]
        public async Task<IEnumerable<StatusHistory>> Get(string list="", bool? status=null)
        {
            return await _manager.GetLatestStatusHistory(list, status);
        }


    }
}
