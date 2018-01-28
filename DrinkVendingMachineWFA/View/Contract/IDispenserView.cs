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
        //void DrawCans();

        void RefreshDispenser(List<DrinkButton> drinkButtons);
    }
}
