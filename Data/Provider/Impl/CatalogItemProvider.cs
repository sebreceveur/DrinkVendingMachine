using System;
using DrinkVendingMachine.Data.Provider.Contract;

namespace DrinkVendingMachine.Data.Provider.Impl
{
    public class CatalogItemProvider: ICatalogItemProvider
    {

        private readonly DataBaseContext _context;

        public CatalogItemProvider(DataBaseContext context)
        {
            _context = context;
        }
    }
}
