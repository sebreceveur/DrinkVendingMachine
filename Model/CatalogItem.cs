using System;
namespace DrinkVendingMachine.Model
{
    public class CatalogItem
    {
        public int ID { get; set; }
        public int DrinkID { get; set; } // FK
        public int Quantity { get; set; }
        //public int DrinkStoreID { get; set; } // FK

        public Drink Drink { get; set; }
        //public DrinkStore DrinkStore { get; set; }

        public CatalogItem()
        {
        }
    }
}
