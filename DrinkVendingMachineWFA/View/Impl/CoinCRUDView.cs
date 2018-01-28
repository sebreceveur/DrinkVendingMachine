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
using DrinkVendingMachineWFA.Service;

namespace DrinkVendingMachineWFA.View.Impl
{
    public partial class CoinCRUDView : UserControl, ICoinView
    {
        public CoinCRUDView()
        {
            InitializeComponent();

        }

        public void SetDataGrid(object dataSource)
        {
            dataGridView1.DataSource = dataSource;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
