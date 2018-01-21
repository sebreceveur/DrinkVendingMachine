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

            //var coins = _context.Coins.ToList();

            //var tmp = new List<decimal>();
            //GiveBackMoney(1.20m, 5, tmp);

            var tmp = new List<decimal>();
            GiveBackMoney(1.20m, 5, tmp, new List<decimal>() { 5, 5, 1, 1, 0.5m, 0.5m, 0.20m, 0.20m, 0.20m, 0.20m, 0.20m, 0.20m, 0.20m, 0.10m, 0.10m, 0.10m, 0.10m, 0.10m, 0.10m });

            decimal total = tmp.Sum();

            return View();
        }


        // for this algorithm we don't need to care about which exact coin is inserted, but we only need the total
        // we'll do a IsCoinsStorable though!
        private List<Decimal> GiveBackMoney(decimal itemPrice, decimal givenMoney, List<decimal> givenBackMoney, List<decimal> moneyAvailable)
        {

            // Money is not enough to pay
            if (givenMoney < itemPrice)
            {
                return null;
            }


            decimal tmp = givenBackMoney.Sum();

            if (givenMoney - itemPrice - Coin.Five - tmp >= 0 && moneyAvailable.Where(value => value == Coin.Five).Any())
            {
                moneyAvailable.Remove(moneyAvailable.Where(value => value == Coin.Five).First());
                givenBackMoney.Add(Coin.Five);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney, moneyAvailable);

            }
            else if (givenMoney - itemPrice - Coin.Two - tmp >= 0 && moneyAvailable.Where(value => value == Coin.Two).Any())
            {
                moneyAvailable.Remove(moneyAvailable.Where(value => value == Coin.Two).First());
                givenBackMoney.Add(Coin.Two);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney, moneyAvailable);
            }
            else if (givenMoney - itemPrice - Coin.One - tmp >= 0 && moneyAvailable.Where(value => value == Coin.One).Any())
            {
                moneyAvailable.Remove(moneyAvailable.Where(value => value == Coin.One).First());
                givenBackMoney.Add(Coin.One);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney, moneyAvailable);
            }
            else if (givenMoney - itemPrice - Coin.FiftyCent - tmp >= 0 && moneyAvailable.Where(value => value == Coin.FiftyCent).Any())
            {
                moneyAvailable.Remove(moneyAvailable.Where(value => value == Coin.FiftyCent).First());
                givenBackMoney.Add(Coin.FiftyCent);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney, moneyAvailable);
            }
            else if (givenMoney - itemPrice - Coin.TwentyCent - tmp >= 0 && moneyAvailable.Where(value => value == Coin.TwentyCent).Any())
            {
                moneyAvailable.Remove(moneyAvailable.Where(value => value == Coin.TwentyCent).First());
                givenBackMoney.Add(Coin.TwentyCent);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney, moneyAvailable);
            }

            else if (givenMoney - itemPrice - Coin.TenCent - tmp >= 0 && moneyAvailable.Where(value => value == Coin.TenCent).Any())
            {
                moneyAvailable.Remove(moneyAvailable.Where(value => value == Coin.TenCent).First());
                givenBackMoney.Add(Coin.TenCent);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney, moneyAvailable);
            }
            else if (givenMoney - itemPrice - Coin.FiveCent - tmp >= 0 && moneyAvailable.Where(value => value == Coin.FiveCent).Any())
            {
                moneyAvailable.Remove(moneyAvailable.Where(value => value == Coin.FiveCent).First());
                givenBackMoney.Add(Coin.FiveCent);
                return GiveBackMoney(itemPrice, givenMoney, givenBackMoney, moneyAvailable);
            }

            else
            {
                return givenBackMoney;
            }

        }

        private List<Decimal> GiveBackMoney(decimal itemPrice, decimal givenMoney, List<decimal> givenBackMoney){

            // Money is not enough to pay
            if(givenMoney < itemPrice){
                return null;
            }

            decimal tmp = givenBackMoney.Sum();

            switch (givenMoney - itemPrice - tmp)
            {
                case decimal n when (n >= Coin.Five):
                    givenBackMoney.Add(Coin.Five);
                    return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);
                case decimal n when (n >= Coin.Two):
                    givenBackMoney.Add(Coin.Two);
                    return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);
                case decimal n when (n >= Coin.One):
                    givenBackMoney.Add(Coin.One);
                    return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);
                case decimal n when (n >= Coin.FiftyCent):
                    givenBackMoney.Add(Coin.FiftyCent);
                    return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);
                case decimal n when (n >= Coin.TwentyCent):
                    givenBackMoney.Add(Coin.TwentyCent);
                    return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);
                case decimal n when (n >= Coin.TenCent):
                    givenBackMoney.Add(Coin.TenCent);
                    return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);
                case decimal n when (n >= Coin.FiveCent):
                    givenBackMoney.Add(Coin.FiveCent);
                    return GiveBackMoney(itemPrice, givenMoney, givenBackMoney);
                default: // recursion end
                    return givenBackMoney;
            }



        }

    }
}
