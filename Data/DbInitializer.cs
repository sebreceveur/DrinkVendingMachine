using System;
using System.Linq;
using DrinkVendingMachine.Model;

namespace DrinkVendingMachine.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataBaseContext context)
        {
            context.Database.EnsureCreated();

            if (context.Drinks.Any())
            {
                return;   // DB has been seeded
            }

            var drinkStore = new DrinkStore { };
            context.DrinkStore.Add(drinkStore);
            context.SaveChanges();

            var drinks = new Drink[]{
                new Drink{Code="COKE",Description="Coca-Cola",Price=1.20m},
                new Drink{Code="WAT",Description="Water",Price=1},
                new Drink{Code="FAN", Description="Fanta", Price=1.6m}
            };

            foreach (Drink s in drinks)
            {
                context.Drinks.Add(s);
            }
            context.SaveChanges();


            var items = new CatalogItem[]{
                //new CatalogItem{ DrinkID = 1, Quantity = 20, DrinkStoreID = drinkStore.ID},
                //new CatalogItem{ DrinkID = 2, Quantity = 10, DrinkStoreID = drinkStore.ID},
                //new CatalogItem{ DrinkID = 3, Quantity = 15, DrinkStoreID = drinkStore.ID},

                new CatalogItem{ DrinkID = 1, Quantity = 20},
                new CatalogItem{ DrinkID = 2, Quantity = 10},
                new CatalogItem{ DrinkID = 3, Quantity = 15},
            };           

            foreach (CatalogItem i in items)
            {
                context.CatalogItems.Add(i);
            }
           context.SaveChanges();

            var coins = new CoinStore[]{
                new CoinStore{ Value = Coin.Five, Quantity = 10},
                new CoinStore{ Value = Coin.Two, Quantity = 10},
                new CoinStore{ Value = Coin.One, Quantity = 20},
                new CoinStore{ Value = Coin.FiftyCent, Quantity = 10},
                new CoinStore{ Value = Coin.TwentyCent, Quantity = 15},
                new CoinStore{ Value = Coin.TenCent, Quantity = 15},
                new CoinStore{ Value = Coin.FiveCent, Quantity = 20},
            };

            foreach(var c in coins){
                context.Coins.Add(c);
            }
            context.SaveChanges();



        }
    }

}
