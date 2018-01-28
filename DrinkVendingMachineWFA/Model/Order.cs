using System;
using System.Collections.Generic;

namespace DrinkVendingMachineWFA.Model
{
    public class Order
    {
        public IEnumerable<CoinStore> coinInserted { get; set; }
        public Drink selectedDrinkCan { get; set; }

        public Order()
        {
        }
    }
}
