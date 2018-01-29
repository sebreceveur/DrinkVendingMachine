using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrinkVendingMachineWFA.View.Contract;

namespace DrinkVendingMachineWFA.View.Impl
{
    public partial class CoinStorageView : UserControl, ICoinStorageView
    {
        public CoinStorageView()
        {
            InitializeComponent();

            RefreshCoinStorage();
        }

        public void RefreshCoinStorage()
        {
            Panel coin = new Panel();
            coin.Height = 10;
            coin.Width = 60;
            coin.BackColor = Color.LightGray;

            for(int i = 0; i < 4; i++)
            {
                flowLayoutPanel5CHF.Controls.Add(new Panel()
                {
                    Height = 8,
                    Width = 50,
                    BackColor = Color.LightGray,
                    Margin = new Padding(1, 1, 1, 1)
                });
            }
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
