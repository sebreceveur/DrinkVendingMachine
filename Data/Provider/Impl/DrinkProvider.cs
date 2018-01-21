using System;
using System.Linq;
using System.Collections.Generic;
using DrinkVendingMachine.Data.Provider.Contract;
using DrinkVendingMachine.Model;

namespace DrinkVendingMachine.Data.Provider.Impl
{
    public class DrinkProvider: IDrinkProvider
    {

        private readonly DataBaseContext _context;

        public DrinkProvider(DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Drink> GetDrinks()
        {
            var drinks = (from d in this._context.Drinks.ToList()
                          join cat in this._context.CatalogItems.ToList()
                          on d.ID equals cat.DrinkID
                          where cat.Quantity > 0
                          select new Drink
                          {
                              ID = d.ID,
                              Code = d.Code,
                              Description = d.Description,
                              Price = d.Price,
                              Color = d.Color
                          }).ToList();

            return drinks;
        }

        public void RemoveDrink(Drink drink){

            CatalogItem itemToDecrease = _context.CatalogItems.Where(arg => arg.DrinkID == drink.ID).First();
            itemToDecrease.Quantity--;

            _context.CatalogItems.Update(itemToDecrease);
            _context.SaveChanges();

        }


    }
}
