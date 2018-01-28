using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkVendingMachineWFA.View.Contract
{
    interface ICoinView
    {
        void SetDataGrid(object dataSource);

        event EventHandler InsertData;

        event EventHandler UpdateData;

        event EventHandler DeleteData;

        event EventHandler SomeEventChanged;
    }
}
