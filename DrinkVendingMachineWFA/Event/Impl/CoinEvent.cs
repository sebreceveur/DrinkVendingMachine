using DrinkVendingMachineWFA.Model;

namespace DrinkVendingMachineWFA.Event.Impl
{
    class CoinEvent : ApplicationMessage
    {
        public CoinStore CoinStore { get; private set; }
        public CoinEvent(int id, int capacity, int quantity, decimal value)
        {

            CoinStore = new CoinStore() { ID = id, Capacity = capacity, Quantity = quantity, Value = value};
        }

       
    }
}
