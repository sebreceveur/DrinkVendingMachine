using System;
using System.Collections.Generic;
using System.Linq;
using DrinkVendingMachine.Data.Provider.Contract;
using DrinkVendingMachine.Model;

namespace DrinkVendingMachine.Data.Provider.Impl
{
    /// <summary>
    /// CoinStoreP rovider allows to access to Coin storage in the db.
    /// </summary>
    public class CoinStoreProvider: ICoinStoreProvider
    {

        private readonly DataBaseContext _context;

        public CoinStoreProvider(DataBaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all the coins.
        /// </summary>
        /// <returns>The coins.</returns>
        public IEnumerable<CoinStore> GetCoins()
        {
            return _context.Coins.ToList();
        }

        /// <summary>
        /// Update the specified coins.
        /// </summary>
        /// <remarks>Increase the quantities for the different coins specicied in parameter.</remarks>
        /// <returns>The update.</returns>
        /// <param name="coinInserted">Coin inserted.</param>
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

        /// <summary>
        /// Removes the change to the storage.
        /// </summary>
        /// <remarks>Decrease the quantities for the different coins specicied in parameter.
        /// </remarks>
        /// <param name="giveBackMoney">Give back money.</param>
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

        /// <summary>
        /// Gets the available money in the storage.
        /// </summary>
        /// <returns>The available money as a decimal list.</returns>
        public List<decimal> GetAvailableMoney(){
            var storage = _context.Coins.ToList();
            List<decimal> moneyAvailable = new List<decimal>();

            foreach(var item in storage){
                switch (item.Value)
                {
                    case Coin.Five:                        
                        moneyAvailable.AddRange(Enumerable.Repeat(Coin.Five, item.Quantity));
                        break;
                    case Coin.Two:
                        moneyAvailable.AddRange(Enumerable.Repeat(Coin.Two, item.Quantity));
                        break;
                    case Coin.One:
                        moneyAvailable.AddRange(Enumerable.Repeat(Coin.One, item.Quantity));
                        break;
                    case Coin.FiftyCent:
                        moneyAvailable.AddRange(Enumerable.Repeat(Coin.FiftyCent, item.Quantity));
                        break;

                    case Coin.TwentyCent:
                        moneyAvailable.AddRange(Enumerable.Repeat(Coin.TwentyCent, item.Quantity));
                        break;

                    case Coin.TenCent:
                        moneyAvailable.AddRange(Enumerable.Repeat(Coin.TenCent, item.Quantity));
                        break;

                    case Coin.FiveCent:
                        moneyAvailable.AddRange(Enumerable.Repeat(Coin.FiveCent, item.Quantity));
                        break;
                }
            }

            return moneyAvailable;

        }


    }
}
