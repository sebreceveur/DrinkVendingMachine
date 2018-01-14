using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkVendingMachine.Model
{
    public class DrinkStore
    {
        public int ID { get; set; }

        //public ICollection<CatalogItem> CatalogItems { get; set; }

        public DrinkStore()
        {
        }
    }
}
