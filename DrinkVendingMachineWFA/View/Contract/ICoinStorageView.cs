using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkVendingMachineWFA.View.Contract
{
    public interface ICoinStorageView
    {
        void RefreshCoinStorage(Dictionary<decimal, int> coinQuantity);
    }
}
