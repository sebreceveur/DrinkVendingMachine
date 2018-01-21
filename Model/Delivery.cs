using System;
using System.Collections.Generic;

namespace DrinkVendingMachine.Model
{
    public class Delivery
    {
        public List<Decimal> Coins { get; set; }
        public Drink Drink { get; set; }

        public Delivery()
        {
        }
    }
}
