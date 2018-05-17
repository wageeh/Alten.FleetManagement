using Core.BaseRepository;
using Core.DbEntites.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracker.BusinessModel;
using VehicleTracker.DTO;

namespace VehicleTracker.API.BL
{
    public class StatusManager
    {
        private readonly IBaseRepository<VehicleStatus> _repository;

        public StatusManager(IBaseRepository<VehicleStatus> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StatusHistory>> GetLatestStatusHistory(string vehiclelist, bool? vehiclestatus)
        {
            var predicate = PredicateBuilder.True<VehicleStatus>();
            if (vehiclelist!= null && !vehiclelist.Equals(""))
            {
                predicate = predicate.And(l => vehiclelist.Contains(l.Vehicle.RegistrationNumber));
            }
            if (vehiclestatus.HasValue)
            {
                predicate = predicate.And(l => l.Status == vehiclestatus.Value);
            }
            
            var vehicleStatus = await _repository
                .WhereOrdered(predicate, item => item.CreatedDate, includedentity => includedentity.Vehicle);

            List<StatusHistory> lsthistory = (from vs in vehicleStatus
                                             select new StatusHistory()
                                             {
                                                 CreatedDate = vs.CreatedDate,
                                                 RegistrationNumber = vs.Vehicle.RegistrationNumber,
                                                 Status = vs.Status
                                             }).Distinct(new PropertyComparer<StatusHistory>("RegistrationNumber")).ToList();


            return lsthistory;
        }

        public void InsertRange(List<VehicleStatus>vehiclestatuslist)
        {
            _repository.InsertRange(vehiclestatuslist);
        }
    }
}
