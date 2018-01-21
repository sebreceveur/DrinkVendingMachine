using System;
using System.Collections.Generic;
using System.Linq;
using DrinkVendingMachine.Data.Provider.Contract;
using DrinkVendingMachine.Model;

namespace DrinkVendingMachine.Data.Provider.Impl
{
    public class CoinStoreProvider: ICoinStoreProvider
    {

        private readonly DataBaseContext _context;

        public CoinStoreProvider(DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<CoinStore> GetCoins()
        {
            return _context.Coins.ToList();
        }

        public void Update(IEnumerable<CoinStore> coinInserted)
        {
            IEnumerable<CoinStore> coins = _context.Coins.ToList();
            
            // adding client money to the money storage 
            coins.Where(coin => coin.Value == Coin.Five).First().Quantity += coinInserted.Count(coin => coin.Value == Coin.Five);
            coins.Where(coin => coin.Value == Coin.Two).First().Quantity += coinInserted.Count(coin => coin.Value == Coin.Two);
            coins.Where(coin => coin.Value == Coin.One).First().Quantity += coinInserted.Count(coin => coin.Value == Coin.One);
            coins.Where(coin => coin.Value == Coin.FiftyCent).First().Quantity += coinInserted.Count(coin => coin.Value == Coin.FiftyCent);
            coins.Where(coin => coin.Value == Coin.TwentyCent).First().Quantity += coinInserted.Count(coin => coin.Value == Coin.TwentyCent);
            coins.Where(coin => coin.Value == Coin.TenCent).First().Quantity += coinInserted.Count(coin => coin.Value == Coin.TenCent);
            coins.Where(coin => coin.Value == Coin.FiveCent).First().Quantity += coinInserted.Count(coin => coin.Value == Coin.FiveCent);

            _context.Coins.UpdateRange(coins);
            _context.SaveChanges();
        }

        public void RemoveChange(IEnumerable<decimal> giveBackMoney){
            IEnumerable<CoinStore> coins = _context.Coins.ToList();

            // removing CHANGE money from the storage
            coins.Where(coin => coin.Value == Coin.Five).First().Quantity -= giveBackMoney.Count(d => d == Coin.Five);
            coins.Where(coin => coin.Value == Coin.Two).First().Quantity -= giveBackMoney.Count(d => d == Coin.Two);
            coins.Where(coin => coin.Value == Coin.One).First().Quantity -= giveBackMoney.Count(d => d == Coin.One);
            coins.Where(coin => coin.Value == Coin.FiftyCent).First().Quantity -= giveBackMoney.Count(d => d == Coin.FiftyCent);
            coins.Where(coin => coin.Value == Coin.TwentyCent).First().Quantity -= giveBackMoney.Count(d => d == Coin.TwentyCent);
            coins.Where(coin => coin.Value == Coin.TenCent).First().Quantity -= giveBackMoney.Count(d => d == Coin.TenCent);
            coins.Where(coin => coin.Value == Coin.FiveCent).First().Quantity -= giveBackMoney.Count(d => d == Coin.FiveCent);

            _context.Coins.UpdateRange(coins);
            _context.SaveChanges();
        }

        public List<decimal> GetAvailableMoney(){
            var storage = _context.Coins.ToList();
            IEnumerable<decimal> moneyAvailable = new List<decimal>();

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

            return moneyAvailable;

        }


    }
}
