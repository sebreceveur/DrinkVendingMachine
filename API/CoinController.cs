using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkVendingMachine.Data;
using DrinkVendingMachine.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkVendingMachine.API
{
    [Route("api/[controller]")]
    public class CoinController : Controller
    {
        private readonly DataBaseContext _context;
        public CoinController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<CoinStore> Get()
        {
            return _context.Coins.ToList();
        }

    }
}
