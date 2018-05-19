using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetManager.DTO;
using Core.BaseRepository;
using Core.DbEntites.Helpers;
using System.Linq.Expressions;

namespace FleetManager.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Clients")]
    public class ClientsController : Controller
    {
        private readonly IBaseRepository<Client> _clientrepository;

        public ClientsController(IBaseRepository<Client> clientrepository)
        {
            _clientrepository = clientrepository;
        }

        public async Task<IEnumerable<Client>> Get()
        {
            var predicate = PredicateBuilder.True<Client>();
            var clients = await _clientrepository.WhereOrdered(predicate
                , oitem => oitem.CreatedDate, item => item.Vehicles);
                
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
            var client = await _clientrepository.WhereOrdered(c=> c.Id == id, oitem => oitem.CreatedDate, item => item.Vehicles);
            return client.FirstOrDefault();
        }


    }
}
