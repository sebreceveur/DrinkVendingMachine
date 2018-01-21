using System;
using System.Collections.Generic;
using DrinkVendingMachine.Model;

namespace DrinkVendingMachine.Data.Provider.Contract
{
    public interface IDrinkProvider
    {
        IEnumerable<Drink> GetDrinks();

        void RemoveDrink(Drink drink);
    }
}
