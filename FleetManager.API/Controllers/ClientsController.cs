using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetManager.Entities;
using FleetManager.API.Repository;

namespace FleetManager.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Clients")]
    public class ClientsController : Controller
    {
        private readonly FleetManagerContext _context;

        public ClientsController(FleetManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> Get()
        {
            var clients = await _context.Clients
                .Include(u => u.Vehicles)
                .ToListAsync();
            return clients;           
        }
        [HttpGet("{id}")]
        public async Task<Client> Get(string customerid)
        {
            Guid id;
            if (customerid == null || customerid.Equals(""))
            {
                throw new Exception("No customer id provided");
            }
            else if (!Guid.TryParse(customerid,out id))
            {
                throw new FormatException("Wrong customer id");
            }
            var client = await _context.Clients
                .Include(u => u.Vehicles)
                .Where(c=> c.Id == id)
                .FirstOrDefaultAsync();
            return client;
        }


    }
}
