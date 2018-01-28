using System;
namespace DrinkVendingMachineWFA.Model
{
    /// <summary>
    /// Reprends the quantity of a item that is sold by the vending machine
    /// </summary>
    public class CatalogItem
    {
        public int ID { get; set; }
        public int DrinkID { get; set; } // FK
        public int Quantity { get; set; }

        public Drink Drink { get; set; }
        //public DrinkStore DrinkStore { get; set; }

        public CatalogItem()
        {
        }
    }
}
