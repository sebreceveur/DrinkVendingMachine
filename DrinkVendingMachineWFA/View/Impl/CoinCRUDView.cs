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
using DrinkVendingMachineWFA.Event.Impl;
using DrinkVendingMachineWFA.Model;

namespace DrinkVendingMachineWFA.View.Impl
{
    public partial class CoinCRUDView : UserControl, ICoinView
    {
        private int ID = 0;

        public CoinCRUDView()
        {
            InitializeComponent();

            updateBtn.Click += (sender, e) =>
            {
                if(ID != null && !String.IsNullOrEmpty(capacityBox.Text) 
                && !String.IsNullOrEmpty(quantityBox.Text) && !String.IsNullOrEmpty(valueBox.Text))
                {
                    EventAggregator.Instance.Publish(
                    new ApplicationMessageGeneric<CoinStore>(new CoinStore()
                    {
                        ID = this.ID,
                        Capacity = Convert.ToInt32(capacityBox.Text),
                        Quantity = Convert.ToInt32(quantityBox.Text),
                        Value = Convert.ToDecimal(valueBox.Text)
                    }));
                }


            };
        }


        public void SetDataGrid(object dataSource)
        {
            dataGridView1.DataSource = dataSource;
        }

        private void CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            valueBox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();            
            quantityBox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            capacityBox.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        // events





        private void InsertBtn_Click(object sender, EventArgs e)
        {

        }

        //private void UpdateBtn_Click(object sender, EventArgs e)
        //{

        //    EventAggregator.Instance.Publish(
        //        new ApplicationMessageGeneric<CoinStore>(new CoinStore()
        //        {
        //            ID = this.ID,
        //            Capacity = Convert.ToInt32(capacityBox.Text),
        //            Quantity = Convert.ToInt32(quantityBox.Text),
        //            Value = Convert.ToDecimal(valueBox.Text)
        //        }));
        //}

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
