using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleTracker.BusinessModel
{
    public class StatusHistory
    {
        public bool Status { get; set; }

        public string RegistrationNumber { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public bool StatusOld
        {
            get
            {
                TimeSpan elpasedDate = DateTime.Now.Subtract(CreatedDate);
                return elpasedDate.TotalMinutes > 5;
            }
        }
    }
}
