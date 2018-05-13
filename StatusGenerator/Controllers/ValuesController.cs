using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StatusGenerator.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        

        // return rondom status for each call with vehicle id
        [HttpGet("{id}")]
        public bool? Get(string id)
        {
            Random random = new Random();
            int newstaus = random.Next(0,3);
            switch (newstaus)
            {
                case 0:
                    return true;
                case 1:
                    return false;
                default:
                    return null;
            }
        }

        
    }
}
