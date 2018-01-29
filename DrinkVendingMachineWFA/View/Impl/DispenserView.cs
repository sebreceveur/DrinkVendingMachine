using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkVendingMachineWFA.View.Contract;
using System.Windows.Forms;
using DrinkVendingMachineWFA.Helper;
using DrinkVendingMachineWFA.Model;
using DrinkVendingMachineWFA.Event.Impl;

namespace DrinkVendingMachineWFA.View.Impl
{
    public partial class DispenserView : UserControl, IDispenserView
    {
        private ICoinStorageView _coinStorageView;

        //events
        public event EventHandler Cancel;
        public event EventHandler Order;

        public DispenserView()
        {
            InitializeComponent();
            PrepareCoinDrawer();

            cancelBtn.Click += OnCancel;
            validateBtn.Click += OnOrdering;            
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            Cancel?.Invoke(this, e);

        }

        protected void OnOrdering(object sender, EventArgs e)
        {
            Order?.Invoke(this, e);

        }

        public void RefreshDispenser(List<DrinkButton> drinkButtons)
        {
            drinkButtons.ForEach(btn => btn.Click += PublicDrink);
            flowLayoutCans.Controls.Clear();
            flowLayoutCans.Controls.AddRange(drinkButtons.ToArray());
        }

        public void SetCoinStorageView(Control coinStorageView)
        {
            _coinStorageView = (ICoinStorageView) coinStorageView;

            splitContainer4.Panel1.Controls.Add(coinStorageView);            
        }

        public void WriteMessage(string message)
        {
            if(logMessageBox.Text.Count((i) => i == '\n') > 5 )
            {
                logMessageBox.Text = message + "\r\n";
            }
            else
            {
                logMessageBox.Text +=  message+"\r\n";
            }
            
        }

        private void PrepareCoinDrawer()
        {
            CoinButton btn5ch = new CoinButton(5m)
            {
                Width = 100,
                Height = 100,
                Visible = true
            };
            btn5ch.Text = "5 CHF";

            CoinButton btn2ch = new CoinButton(2m)
            {
                Width = 87,
                Height = 87,
                Visible = true
            };
            btn2ch.Text = "2 CHF";

            CoinButton btn1ch = new CoinButton(1m)
            {
                Width = 74,
                Height = 74,
                Visible = true
            };
            btn1ch.Text = "1 CHF";

            CoinButton btn50Cch = new CoinButton(0.5m)
            {
                Width = 58,
                Height = 58,
                Visible = true
            };
            btn50Cch.Text = "1/2 CHF";

            CoinButton btn20Cch = new CoinButton(0.20m)
            {
                Width = 67,
                Height = 67,
                Visible = true
            };
            btn20Cch.Text = "20c CHF";

            CoinButton btn10Cch = new CoinButton(0.10m)
            {
                Width = 61,
                Height = 61,
                Visible = true
            };
            btn10Cch.Text = "10c CHF";

            CoinButton btn5Cch = new CoinButton(0.05m)
            {
                Width = 55,
                Height = 55,
                Visible = true,
                BackColor = Color.Gold
            };
            btn5Cch.Text = "5c CHF";

            btn5ch.Anchor = AnchorStyles.Bottom;
            btn2ch.Anchor = AnchorStyles.Bottom;
            btn1ch.Anchor = AnchorStyles.Bottom;
            btn50Cch.Anchor = AnchorStyles.Bottom;
            btn20Cch.Anchor = AnchorStyles.Bottom;
            btn10Cch.Anchor = AnchorStyles.Bottom;
            btn5Cch.Anchor = AnchorStyles.Bottom;

            //register to notify subscriber when click
            btn5ch.Click += Publish;
            btn2ch.Click += Publish;
            btn1ch.Click += Publish;
            btn50Cch.Click += Publish;
            btn20Cch.Click += Publish;
            btn10Cch.Click += Publish;
            btn5Cch.Click += Publish;

            flowLayoutPanel1.Controls.Add(btn5ch);
            flowLayoutPanel1.Controls.Add(btn2ch);
            flowLayoutPanel1.Controls.Add(btn1ch);
            flowLayoutPanel1.Controls.Add(btn50Cch);
            flowLayoutPanel1.Controls.Add(btn20Cch);
            flowLayoutPanel1.Controls.Add(btn10Cch);
            flowLayoutPanel1.Controls.Add(btn5Cch);
        }


        private void Publish(object sender, EventArgs e)
        {
            EventAggregator.Instance.Publish(
                new ApplicationMessageGeneric<CoinStore>(new CoinStore()
                {
                    Value = ((CoinButton)sender).Value
                }));
        }

        private void PublicDrink(object sender, EventArgs e)
        {
            EventAggregator.Instance.Publish(
                new ApplicationMessageGeneric<Drink>(new Drink()
                {
                    Code = ((DrinkButton)sender).Code
                }));
        }
    }
}
