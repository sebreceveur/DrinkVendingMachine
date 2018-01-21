using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkVendingMachine.Business;
using DrinkVendingMachine.Data;
using DrinkVendingMachine.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkVendingMachine.API
{
    [Route("api/[controller]")]
    public class DrinkController : Controller
    {

        private readonly DataBaseContext _context;
        private MoneyHandler moneyHandler; // TODO Injection
        public DrinkController(DataBaseContext context)
        {
            _context = context;
            moneyHandler = new MoneyHandler();
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Drink> Get()
        {
            //return _context.Drinks.ToList();

            var catalog = _context.CatalogItems.ToList();


            //var tmp1 = _context.Drinks.Join(catalog, (arg1) => arg1.ID, (arg2) => arg2.DrinkID, (Drink arg1, CatalogItem arg2) => new { arg1, arg2 });
            //var tmp2 = tmp1.Where((arg) => arg.arg2.Quantity > 0);
            //var tmp3 = tmp2.Select((arg1, arg2) => arg1.arg1);

            //IEnumerable<Drink> tmp = _context.Drinks.Join(catalog, (arg1) => arg1.ID, (arg2) => arg2.DrinkID, (Drink arg1, CatalogItem arg2) => new { arg1, arg2 })
            //.Where((arg1, arg2) => arg1.arg2.Quantity > 0)
            //.Select((arg1, arg2) => arg1.arg1);

            //return tmp3;
            //.Where(((Drink, CatalogItem) arg) => arg.Item2.Quantity > 0).Select(((Drink, CatalogItem) arg) => arg.Item1);



            var drinks = (from d in this._context.Drinks
                          join cat in this._context.CatalogItems
                          on d.ID equals cat.DrinkID
                          where cat.Quantity > 0
                          select new Drink
                          {
                            ID = d.ID,
                            Code = d.Code,
                            Description = d.Description,
                            Price = d.Price,
                            Color = d.Color
                          }).ToList();
                         
            return drinks;

            //var person = (from p in db.People
                          //join e in db.EmailAddresses
                          //on p.BusinessEntityID equals e.BusinessEntityID
                          //where p.FirstName == "KEN"
                          //select new
                          //{
                          //    ID = p.BusinessEntityID,
                          //    FirstName = p.FirstName,
                          //    MiddleName = p.MiddleName,
                          //    LastName = p.LastName,
                          //    EmailID = e.EmailAddress1
                          //}).ToList();

        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]Order order)
        {
            if (order.selectedDrinkCan != null && order.selectedDrinkCan.ID > 0)
            {
                CatalogItem item = _context.CatalogItems.Where((arg) => arg.DrinkID == order.selectedDrinkCan.ID).First();

                var giveBackMoney = new List<decimal>();
                var toLoad = new List<CoinStore>();

                // TODO
                if (moneyHandler.AreCoinsStorable(order.coinInserted.Select(c => c.Value).ToList(), toLoad))
                {

                    List<decimal> moneyAvailable = new List<decimal>();
                    var storage = _context.Coins.ToList();

                    //storage.Where(coin => coin.Value == Coin.Five).First();
                    storage.ForEach((obj) =>
                    {
                        switch (obj.Value)
                        {
                            case Coin.Five:
                                for (int i = 0; i < obj.Quantity; i++)
                                {
                                    moneyAvailable.Add(Coin.Five);
                                }
                                break;
                            case Coin.Two:
                                for (int i = 0; i < obj.Quantity; i++)
                                {
                                    moneyAvailable.Add(Coin.Two);
                                }
                                break;

                            case Coin.One:
                                for (int i = 0; i < obj.Quantity; i++)
                                {
                                    moneyAvailable.Add(Coin.One);
                                }
                                break;
                            case Coin.FiftyCent:
                                for (int i = 0; i < obj.Quantity; i++)
                                {
                                    moneyAvailable.Add(Coin.FiftyCent);
                                }
                                break;

                            case Coin.TwentyCent:
                                for (int i = 0; i < obj.Quantity; i++)
                                {
                                    moneyAvailable.Add(Coin.TwentyCent);
                                }
                                break;

                            case Coin.TenCent:
                                for (int i = 0; i < obj.Quantity; i++)
                                {
                                    moneyAvailable.Add(Coin.TenCent);
                                }
                                break;

                            case Coin.FiveCent:
                                for (int i = 0; i < obj.Quantity; i++)
                                {
                                    moneyAvailable.Add(Coin.FiveCent);
                                }
                                break;
                        }
                    });

                    moneyHandler.GiveBackMoney(order.selectedDrinkCan.Price, order.coinInserted.Sum(coin => coin.Value), giveBackMoney, moneyAvailable);

                    // adding client money to the money storage 
                    storage.Where(coin => coin.Value == Coin.Five).First().Quantity += order.coinInserted.Count(coin => coin.Value == Coin.Five);
                    storage.Where(coin => coin.Value == Coin.Two).First().Quantity += order.coinInserted.Count(coin => coin.Value == Coin.Two);
                    storage.Where(coin => coin.Value == Coin.One).First().Quantity += order.coinInserted.Count(coin => coin.Value == Coin.One);
                    storage.Where(coin => coin.Value == Coin.FiftyCent).First().Quantity += order.coinInserted.Count(coin => coin.Value == Coin.FiftyCent);
                    storage.Where(coin => coin.Value == Coin.TwentyCent).First().Quantity += order.coinInserted.Count(coin => coin.Value == Coin.TwentyCent);
                    storage.Where(coin => coin.Value == Coin.TenCent).First().Quantity += order.coinInserted.Count(coin => coin.Value == Coin.TenCent);
                    storage.Where(coin => coin.Value == Coin.FiveCent).First().Quantity += order.coinInserted.Count(coin => coin.Value == Coin.FiveCent);

                    // removing CHANGE money from the storage
                    storage.Where(coin => coin.Value == Coin.Five).First().Quantity -= giveBackMoney.Count(d => d == Coin.Five);
                    storage.Where(coin => coin.Value == Coin.Two).First().Quantity -= giveBackMoney.Count(d => d == Coin.Two);
                    storage.Where(coin => coin.Value == Coin.One).First().Quantity -= giveBackMoney.Count(d => d == Coin.One);
                    storage.Where(coin => coin.Value == Coin.FiftyCent).First().Quantity -= giveBackMoney.Count(d => d == Coin.FiftyCent);
                    storage.Where(coin => coin.Value == Coin.TwentyCent).First().Quantity -= giveBackMoney.Count(d => d == Coin.TwentyCent);
                    storage.Where(coin => coin.Value == Coin.TenCent).First().Quantity -= giveBackMoney.Count(d => d == Coin.TenCent);
                    storage.Where(coin => coin.Value == Coin.FiveCent).First().Quantity -= giveBackMoney.Count(d => d == Coin.FiveCent);

                    _context.Coins.UpdateRange(storage);
                    _context.SaveChanges();

                    return true;
                }

                //if (item.Quantity > 0)
                //{
                //    item.Quantity--;
                //    _context.CatalogItems.Update(item);
                //    _context.SaveChanges();
                //    return true;
                //}
            }

            return false;
        }
    }
}
