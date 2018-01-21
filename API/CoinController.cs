using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkVendingMachine.Data;
using DrinkVendingMachine.Data.Provider.Contract;
using DrinkVendingMachine.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkVendingMachine.API
{
    [Route("api/[controller]")]
    public class CoinController : Controller
    {

        private readonly ICoinStoreProvider _coinProvider;

        public CoinController(ICoinStoreProvider coinProvider)
        {
            _coinProvider = coinProvider;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<CoinStore> Get()
        {
            return _coinProvider.GetCoins();
        }

    }
}
