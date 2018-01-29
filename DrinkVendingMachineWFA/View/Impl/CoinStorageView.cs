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
        }

        public void RefreshCoinStorage(Dictionary<decimal, int> coinQuantity)
        {
            Panel coin = new Panel();
            coin.Height = 8;
            coin.Width = 50;
            coin.BackColor = Color.LightGray;

            flowLayoutPanel5CHF.Controls.Clear();
            flowLayoutPanel2CHF.Controls.Clear();
            flowLayoutPanel1CHF.Controls.Clear();
            flowLayoutPanelHCHF.Controls.Clear();
            flowLayoutPanel20cCHF.Controls.Clear();
            flowLayoutPanel10cCHF.Controls.Clear();
            flowLayoutPanel5cCHF.Controls.Clear();

            InitLabels();

            int tmp;

            if (coinQuantity.TryGetValue(5m, out tmp))
            {
                flowLayoutPanel5CHF.Controls.AddRange(CreateListPanelCoin(tmp));
                //doesnt work with panels
                //flowLayoutPanel5CHF.Controls.AddRange(Enumerable.Repeat<Panel>(coin, tmp).ToArray());
            }

            if (coinQuantity.TryGetValue(2m, out tmp))
            {
                flowLayoutPanel2CHF.Controls.AddRange(CreateListPanelCoin(tmp));
            }

            if (coinQuantity.TryGetValue(1, out tmp))
            {
                flowLayoutPanel1CHF.Controls.AddRange(CreateListPanelCoin(tmp));
            }

            if (coinQuantity.TryGetValue(0.5m, out tmp))
            {
                flowLayoutPanelHCHF.Controls.AddRange(CreateListPanelCoin(tmp));
            }

            if (coinQuantity.TryGetValue(0.2m, out tmp))
            {
                flowLayoutPanel20cCHF.Controls.AddRange(CreateListPanelCoin(tmp));
            }

            if (coinQuantity.TryGetValue(0.1m, out tmp))
            {
                flowLayoutPanel10cCHF.Controls.AddRange(CreateListPanelCoin(tmp));
            }

            if (coinQuantity.TryGetValue(0.05m, out tmp))
            {
                flowLayoutPanel5cCHF.Controls.AddRange(CreateListPanelCoin(tmp));
            }

        }

        private void InitLabels()
        {
            flowLayoutPanel5CHF.Controls.Add(new Label()
            {
                Text = "5 CHF",
                //Font.Size = 6
            });
            flowLayoutPanel2CHF.Controls.Add(new Label()
            {
                Text = "2 CHF",
                //Font.Size = 6
            });
            flowLayoutPanel1CHF.Controls.Add(new Label()
            {
                Text = "1 CHF",
                //Font.Size = 6
            });
            flowLayoutPanelHCHF.Controls.Add(new Label()
            {
                Text = "50 c",
                //Font.Size = 6
            });
            flowLayoutPanel20cCHF.Controls.Add(new Label()
            {
                Text = "20 c",
                //Font.Size = 6
            });
            flowLayoutPanel10cCHF.Controls.Add(new Label()
            {
                Text = "10 c",
                //Font.Size = 6
            });
            flowLayoutPanel5cCHF.Controls.Add(new Label()
            {
                Text = "5 c",
                //Font.Size = 6
            });
        }

        private Panel[] CreateListPanelCoin(int length)
        {
            List<Panel> panels = new List<Panel>();
            for(int i = 0; i < length; i++)
            {
                panels.Add(new Panel
                {
                    Height = 8,
                    Width = 50,
                    BackColor = Color.LightGray,
                    Margin = new Padding(1, 1, 1, 1)

                });
            }
            return panels.ToArray();
        }

    }
}
