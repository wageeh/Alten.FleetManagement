using Core.DbEntites.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracker.API.Repository;
using VehicleTracker.BusinessModel;
using VehicleTracker.DTO;

namespace VehicleTracker.Business
{
    public class StatusManager
    {

        public async Task<IEnumerable<StatusHistory>> GetLatestStatusHistory(string vehiclelist, bool? vehiclestatus, StatusContext context)
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
            var vehicleStatus = await context.VehicleStatus
                .Include(u => u.Vehicle)
                .Where(predicate)
                .OrderByDescending(s => s.CreatedDate)           
                .ToListAsync();

            List<StatusHistory> lsthistory = (from vs in vehicleStatus
                                             select new StatusHistory()
                                             {
                                                 CreatedDate = vs.CreatedDate,
                                                 RegistrationNumber = vs.Vehicle.RegistrationNumber,
                                                 Status = vs.Status
                                             }).Distinct(new PropertyComparer<StatusHistory>("RegistrationNumber")).ToList();


            return lsthistory;
        }
    }
}
