using DrinkVendingMachineWFA.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrinkVendingMachineWFA.View.Contract
{
    interface IDispenserView
    {
        void SetCoinStorageView(Control coinStorageView);

        void RefreshDispenser(List<DrinkButton> drinkButtons);

        void WriteMessage(string message);

        event EventHandler Cancel;

        event EventHandler Order;
    }
}
