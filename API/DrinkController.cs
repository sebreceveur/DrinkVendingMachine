using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkVendingMachine.Business;
using DrinkVendingMachine.Business.Contract;
using DrinkVendingMachine.Data;
using DrinkVendingMachine.Data.Provider.Contract;
using DrinkVendingMachine.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkVendingMachine.API
{
    [Route("api/[controller]")]
    public class DrinkController : Controller
    {
        
        private readonly IMoneyHandler _moneyHandler;

        private readonly ICatalogItemProvider _catalogItemProvider;
        private readonly ICoinStoreProvider _coinStoreProvider;
        private readonly IDrinkProvider _drinkProvider;

        public DrinkController(IMoneyHandler moneyHandler, ICatalogItemProvider catalogItemProvider, ICoinStoreProvider coinStoreProvider, IDrinkProvider drinkProvider)
        {
            _moneyHandler = moneyHandler;

            _catalogItemProvider = catalogItemProvider;
            _coinStoreProvider = coinStoreProvider;
            _drinkProvider = drinkProvider;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Drink> Get()
        {
            return _drinkProvider.GetDrinks();
        }

        // POST api/values
        [HttpPost]
        public Delivery Post([FromBody]Order order)
        {
            if (order != null && order.selectedDrinkCan != null &&
                    order.selectedDrinkCan.ID > 0 && order.coinInserted!=null && order.coinInserted.Count() > 0)
            {
                var giveBackMoney = new List<decimal>();
                var toLoad = new List<CoinStore>();

                // TODO implement AreCoinsStorable
                if (_moneyHandler.AreCoinsStorable(order.coinInserted.Select(c => c.Value).ToList(), toLoad))
                {

                    List<decimal> moneyAvailable = _coinStoreProvider.GetAvailableMoney();

                    _moneyHandler.GiveBackMoney(order.selectedDrinkCan.Price, order.coinInserted.Sum(coin => coin.Value), giveBackMoney, moneyAvailable);

                    _coinStoreProvider.Update(order.coinInserted);
                    _coinStoreProvider.RemoveChange(giveBackMoney);
                    _drinkProvider.RemoveDrink(order.selectedDrinkCan);

                    return new Delivery()
                    {
                        Drink = order.selectedDrinkCan,
                        Coins = giveBackMoney
                    };
                }

            }

            return null;
        }
    }
}
