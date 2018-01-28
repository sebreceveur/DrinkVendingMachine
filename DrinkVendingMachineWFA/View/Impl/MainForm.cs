using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrinkVendingMachineWFA.View.Impl
{
    public partial class MainForm : Form
    {
        public MainForm(Control coinViewCRUD)
        {
            InitializeComponent();

            coinViewCRUD.Dock = DockStyle.Fill;
            coinCRUDPage.Controls.Add(coinViewCRUD);
        }
    }
}
