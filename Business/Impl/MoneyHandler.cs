using System;
using System.Collections.Generic;
using System.Linq;
using DrinkVendingMachine.Business.Contract;
using DrinkVendingMachine.Data.Provider.Contract;
using DrinkVendingMachine.Model;

namespace DrinkVendingMachine.Business.Impl
{
    public class MoneyHandler: IMoneyHandler
    {
        private readonly ICatalogItemProvider _catalogItemProvider;
        private readonly ICoinStoreProvider _coinStoreProvider;
        private readonly IDrinkProvider _drinkProvider;


        public MoneyHandler(ICatalogItemProvider catalogItemProvider, ICoinStoreProvider coinStoreProvider, IDrinkProvider drinkProvider)
        {

            _catalogItemProvider = catalogItemProvider;
            _coinStoreProvider = coinStoreProvider;
            _drinkProvider = drinkProvider;
        }

        public bool AreCoinsStorable(List<decimal> coins, List<CoinStore> storage){
            // TODO AreCoinsStorable
            return true;
        }

        public List<decimal> GiveBackMoney(decimal itemPrice, decimal givenMoney, List<decimal> givenBackMoney, List<decimal> moneyAvailable){
            return PGiveBackMoney(itemPrice, givenMoney, givenBackMoney, moneyAvailable);
        }

        // for this algorithm we don't need to care about which exact coin is inserted, but we only need the total
        // we'll do a IsCoinsStorable though!
        private List<Decimal> PGiveBackMoney(decimal itemPrice, decimal givenMoney, List<decimal> givenBackMoney, List<decimal> moneyAvailable)
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

    }
}
