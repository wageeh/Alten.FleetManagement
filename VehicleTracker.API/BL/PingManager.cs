using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VehicleTracker.API.Repository;
using VehicleTracker.Entites;

namespace VehicleTracker.API.BL
{
    public class PingManager
    {
        private StatusContext _statusContext;
        private static HttpClient client = new HttpClient();
        private string baseaddress = "";
        public PingManager(StatusContext statuscontext,string clientbaseurl)
        {
            _statusContext = statuscontext;
            baseaddress = clientbaseurl;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<List<VehicleStatus>> UpdateVehicleStatusesAsync()
        {
            var vehiclestatuslist = new List<VehicleStatus>();
            var vehiclelist = await _statusContext.Vehicles
              .ToListAsync();
            foreach (var vehicle in vehiclelist)
            {
                var response = await client.GetAsync(baseaddress + "api/values/" + vehicle.RegistrationNumber);
                string result = await response.Content.ReadAsStringAsync();
                if (result != null && result != "")
                {
                    VehicleStatus vehicleStatus = new VehicleStatus()
                    {
                        VehicleId = vehicle.Id,
                        Status = Convert.ToBoolean(result)
                    };
                    vehiclestatuslist.Add(vehicleStatus);
                }

            }
            await _statusContext.VehicleStatus.AddRangeAsync(vehiclestatuslist);
            await _statusContext.SaveChangesAsync();
            return vehiclestatuslist;
        }
    }
}
