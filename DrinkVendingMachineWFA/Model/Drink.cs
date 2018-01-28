using System;
using System.Collections.Generic;

namespace DrinkVendingMachineWFA.Model
{
    /// <summary>
    /// Drinks represents the differente types of drinks
    /// </summary>
    public class Drink
    {
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>Logical code that could be used for the user to select the item he wants to buy</value>
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }

        public Drink()
        {
        }
    }
}
