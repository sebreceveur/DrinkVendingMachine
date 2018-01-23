using System;
using System.Linq;
using DrinkVendingMachine.Model;

namespace DrinkVendingMachine.Data
{
    /// <summary>
    /// Db initializer. Fills the database with default values.
    /// </summary>
    public static class DbInitializer
    {
        public static void Initialize(DataBaseContext context)
        {
            context.Database.EnsureCreated();

            if (context.Drinks.Any())
            {
                return;   // DB has been seeded
            }

            var drinks = new Drink[]{
                new Drink{Code="COKE",Description="Coca-Cola",Price=1.20m, Color="#eb1c2c"},
                new Drink{Code="WAT",Description="Water",Price=1, Color="#337ab7"},
                new Drink{Code="FAN", Description="Fanta", Price=1.6m, Color="#eb681c"},
                new Drink{Code="RED", Description="Red Bull", Price=2.0m, Color="#9d9d9d"}
            };

            foreach (Drink s in drinks)
            {
                context.Drinks.Add(s);
            }
            context.SaveChanges();


            var items = new CatalogItem[]{

                new CatalogItem{ DrinkID = 1, Quantity = 20},
                new CatalogItem{ DrinkID = 2, Quantity = 10},
                new CatalogItem{ DrinkID = 3, Quantity = 15},
                new CatalogItem{ DrinkID = 4, Quantity = 5 }
            };           

            foreach (CatalogItem i in items)
            {
                context.CatalogItems.Add(i);
            }
           context.SaveChanges();

            var coins = new CoinStore[]{
                new CoinStore{ Value = Coin.Five, Quantity = 0, Capacity = 20},
                new CoinStore{ Value = Coin.Two, Quantity = 5, Capacity = 20},
                new CoinStore{ Value = Coin.One, Quantity = 8, Capacity = 20},
                new CoinStore{ Value = Coin.FiftyCent, Quantity = 8, Capacity = 20},
                new CoinStore{ Value = Coin.TwentyCent, Quantity = 8, Capacity = 20},
                new CoinStore{ Value = Coin.TenCent, Quantity = 8, Capacity = 20},
                new CoinStore{ Value = Coin.FiveCent, Quantity = 5, Capacity = 20},
            };

            foreach(var c in coins){
                context.Coins.Add(c);
            }
            context.SaveChanges();

        }
    }

}
