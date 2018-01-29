using DrinkVendingMachineWFA.View.Contract;
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
        private readonly Control _dispenserView;
        private readonly Control _coinCRUDView;
        //private readonly Control _coinStorageView;
        public MainForm(Control dispenserView,Control coinCRUDView)
        {
            InitializeComponent();

            _dispenserView = dispenserView;
            _coinCRUDView = coinCRUDView;
            //_coinStorageView = coinStorageView;

            _coinCRUDView.Dock = DockStyle.Fill;
            coinCRUDPage.Controls.Add(_coinCRUDView);
            dispenserView.Dock = DockStyle.Fill;
            dispenserTabPage.Controls.Add(dispenserView);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //_dispenserView.DrawCans();
        }
    }
}
