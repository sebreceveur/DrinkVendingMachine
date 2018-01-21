using System;
using System.Collections.Generic;
using DrinkVendingMachine.Model;

namespace DrinkVendingMachine.Business.Contract
{
    public interface IMoneyHandler
    {
        bool AreCoinsStorable(List<decimal> coins, List<CoinStore> storage);

        IEnumerable<decimal> GiveBackMoney(decimal itemPrice, decimal givenMoney, IEnumerable<decimal> givenBackMoney, List<decimal> moneyAvailable);
    }

}