using System;
using System.Collections.Generic;
using DrinkVendingMachine.Model;

namespace DrinkVendingMachine.Data.Provider.Contract
{
    public interface ICoinStoreProvider
    {
        IEnumerable<CoinStore> GetCoins();

        void Update(IEnumerable<CoinStore> coinInserted);

        void RemoveChange(IEnumerable<decimal> giveBackMoney);

        List<decimal> GetAvailableMoney();
    }
}
