using System;
using System.Collections.Generic;

namespace DrinkVendingMachine.Model
{
    public class Drink
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        //public DateTime ExpirationDate { get; set; }
        // ...       


        public Drink()
        {
        }
    }
}
