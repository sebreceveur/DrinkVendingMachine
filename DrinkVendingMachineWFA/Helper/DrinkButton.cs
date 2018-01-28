using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrinkVendingMachineWFA.Helper
{
    public class DrinkButton : Button
    {
        public string Code { get; set; }

        public DrinkButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = System.Drawing.Color.Red;
        }


    }
}
