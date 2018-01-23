using System;
using System.Collections.Generic;
using System.Linq;
using DrinkVendingMachine.Business.Contract;
using DrinkVendingMachine.Data.Provider.Contract;
using DrinkVendingMachine.Model;

namespace DrinkVendingMachine.Business.Impl
{


/// <summary>
/// The Money handler class.
/// Contains an recursive algorithm to give the change back considering a price
/// of an object, the given money, and the money available
/// </summary>
    public class MoneyHandler: IMoneyHandler
    {
        private readonly ICatalogItemProvider _catalogItemProvider;
        private readonly ICoinStoreProvider _coinStoreProvider;
        private readonly IDrinkProvider _drinkProvider;

        public MoneyHandler(){
            
        }

        public MoneyHandler(ICatalogItemProvider catalogItemProvider, ICoinStoreProvider coinStoreProvider, IDrinkProvider drinkProvider)
        {

            _catalogItemProvider = catalogItemProvider;
            _coinStoreProvider = coinStoreProvider;
            _drinkProvider = drinkProvider;
        }

        /// <summary>
        /// Determines whether given money can be inserted in the storage
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns><c>true</c>, if there is enogh space, <c>false</c> otherwise.</returns>
        /// <param name="coins">A decimal list.</param>
        /// <param name="storage">A CoinStore list.</param>
        public bool AreCoinsStorable(List<decimal> coins, List<CoinStore> storage){
            bool capacityUnReached = true;

            if(storage == null || storage.Count() < 1){
                return false;
            }

            foreach(var coin in coins){
                var list = storage.Where(arg => arg.Value == coin);
                if(list.Count()>0){
                    var tmp = list.First();
                    if (tmp.Quantity +  (coins.Count((arg) => arg == coin)) > tmp.Capacity)
                    {
                        // capacity reached for this coin
                        return capacityUnReached = false;
                    }
                }

            }

            return capacityUnReached;
        }

        /// <summary>
        /// Gives the money back.
        /// </summary>
        /// <remarks>For this algorithm we don't need to care about which exact coin is inserted, but we only need the total.
        ///</remarks>
        /// <returns>The money given back.</returns>
        /// <param name="itemPrice">Price to consider for the transaction. A decimal number.</param>
        /// <param name="givenMoney">The money given by the client. A decimal number.</param>
        /// <param name="givenBackMoney">Given back money. A list of decimal.</param>
        /// <param name="moneyAvailable">Money available for the counterparty. Could be seen as a cash register. A list of decimal.</param>
        public List<decimal> GiveBackMoney(decimal itemPrice, decimal givenMoney, List<decimal> givenBackMoney, List<decimal> moneyAvailable){
            // Money is not enough to pay
            if (givenMoney < itemPrice || moneyAvailable == null || moneyAvailable.Count() < 1)
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

    }
}
