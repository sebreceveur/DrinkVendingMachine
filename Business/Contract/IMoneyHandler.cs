using System;
using System.Collections.Generic;
using DrinkVendingMachine.Model;

namespace DrinkVendingMachine.Business.Contract
{
    public interface IMoneyHandler
    {
        bool AreCoinsStorable(List<decimal> coins, List<CoinStore> storage);

        List<decimal> GiveBackMoney(decimal itemPrice, decimal givenMoney, List<decimal> givenBackMoney, List<decimal> moneyAvailable);
    }

}