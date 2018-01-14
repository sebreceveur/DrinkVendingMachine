using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkVendingMachine.Data;
using DrinkVendingMachine.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkVendingMachine.Controllers
{
    public class TestController : Controller
    {

        private readonly DataBaseContext _context;
        public TestController(DataBaseContext context){
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //DrinkStore store = _context.DrinkStore.FirstOrDefault();

            CatalogItem item = _context.CatalogItems.FirstOrDefault();
            Drink drink = _context.Drinks.FirstOrDefault();

            var inventory = _context.CatalogItems.ToList();

            var coins = _context.Coins.ToList();

            var tmp = new List<decimal>();
            GiveBackMoney(1.20m, 5, tmp);

            return View();
        }


        private List<Decimal> GiveBackMoney(decimal itemPrice, decimal givenMoney, List<decimal> givenBackMoney){

            // Money is not enough to pay
            if(givenMoney < itemPrice){
                return null;
            }

            decimal tmp = givenBackMoney.Sum();

            if( givenMoney - itemPrice - Coin.Five - tmp >= 0 ){
                givenBackMoney.Add( Coin.Five);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);

            }else if(givenMoney - itemPrice - Coin.Two - tmp >= 0){
                givenBackMoney.Add( Coin.Two);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);
            }
            else if (givenMoney - itemPrice - Coin.One - tmp >= 0)
            {
                givenBackMoney.Add(Coin.One);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);
            }
            else if (givenMoney - itemPrice - Coin.FiftyCent - tmp >= 0)
            {
                givenBackMoney.Add(Coin.FiftyCent);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);
            }
            else if (givenMoney - itemPrice - Coin.TwentyCent - tmp >= 0)
            {
                givenBackMoney.Add(Coin.TwentyCent);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);
            }
            else if (givenMoney - itemPrice - Coin.TenCent - tmp >= 0)
            {
                givenBackMoney.Add(Coin.TenCent);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);
            }
            else if (givenMoney - itemPrice - Coin.FiveCent - tmp >= 0)
            {
                givenBackMoney.Add(Coin.FiveCent);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);
            }

            // end of the recursion
            else{
                return givenBackMoney;
            }

        }

    }
}
