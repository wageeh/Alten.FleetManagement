using Core.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracker.DTO;

namespace VehicleTracker.API.BL
{
    public class VehicleManager
    {
        private readonly IBaseRepository<Vehicle> _repository;

        public VehicleManager(IBaseRepository<Vehicle> repository)
        {
            _repository = repository;
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            return await _repository.GetAll();
        }
    }
}
