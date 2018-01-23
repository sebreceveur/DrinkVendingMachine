using System;
using DrinkVendingMachine.Data.Provider.Contract;

namespace DrinkVendingMachine.Data.Provider.Impl
{
    /// <summary>
    /// Catalog item provider allows to access to Catalog Item in the db.
    /// </summary>
    public class CatalogItemProvider: ICatalogItemProvider
    {

        private readonly DataBaseContext _context;

        public CatalogItemProvider(DataBaseContext context)
        {
            _context = context;
        }
    }
}
