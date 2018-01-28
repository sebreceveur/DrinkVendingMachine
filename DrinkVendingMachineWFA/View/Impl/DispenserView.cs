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

namespace DrinkVendingMachineWFA.View.Impl
{
    public partial class DispenserView : UserControl, IDispenserView
    {
        public DispenserView()
        {
            InitializeComponent();
            PrepareCoinDrawer();

            //for(int i = 0; i < 4; i++)
            //{
            //    flowLayoutCans.Controls.Add(new DrinkButton() { Width = 60, Height = 100 });
            //}           

        }

        public void RefreshDispenser(List<DrinkButton> drinkButtons)
        {
            flowLayoutCans.Controls.AddRange(drinkButtons.ToArray());
        }



        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    // Call the OnPaint method of the base class.  
        //    base.OnPaint(e);

        //    // Declare and instantiate a new pen.  
        //    using (System.Drawing.Brush brush = new SolidBrush(System.Drawing.Color.Red) )
        //    {
        //        // Draw an aqua rectangle in the rectangle represented by the control.  
        //        e.Graphics.FillRectangle(brush, 30, 30, 60, 100);

        //        e.Graphics.FillRectangle(brush, 150, 30, 60, 100);
               
        //        e.Graphics.FillEllipse(brush, 230, 30, 80, 80);
        //    }
        //}

        //public void DrawCans()
        //{
        //    g = pictureBox1.CreateGraphics();
        //    g.FillRectangle(brush, 30, 30, 60, 100);

        //    g = pictureBox1.CreateGraphics();
        //    g.FillRectangle(brush, 150, 30, 60, 100);
        //}


        private void PrepareCoinDrawer()
        {
            RoundButton btn5ch = new RoundButton()
            {
                Width = 100,
                Height = 100,
                Visible = true

            };
            btn5ch.Text = "5 CHF";

            RoundButton btn2ch = new RoundButton()
            {
                Width = 87,
                Height = 87,
                Visible = true

            };
            btn2ch.Text = "2 CHF";

            RoundButton btn1ch = new RoundButton()
            {
                Width = 74,
                Height = 74,
                Visible = true

            };
            btn1ch.Text = "1 CHF";

            RoundButton btn50Cch = new RoundButton()
            {
                Width = 58,
                Height = 58,
                Visible = true

            };
            btn50Cch.Text = "1/2 CHF";

            RoundButton btn20Cch = new RoundButton()
            {
                Width = 67,
                Height = 67,
                Visible = true

            };
            btn20Cch.Text = "20c CHF";

            RoundButton btn10Cch = new RoundButton()
            {
                Width = 61,
                Height = 61,
                Visible = true

            };
            btn10Cch.Text = "10c CHF";

            RoundButton btn5Cch = new RoundButton()
            {
                Width = 55,
                Height = 55,
                Visible = true

            };
            btn5Cch.Text = "5c CHF";

            btn5ch.Anchor = AnchorStyles.Bottom;
            btn2ch.Anchor = AnchorStyles.Bottom;
            btn1ch.Anchor = AnchorStyles.Bottom;
            btn50Cch.Anchor = AnchorStyles.Bottom;
            btn20Cch.Anchor = AnchorStyles.Bottom;
            btn10Cch.Anchor = AnchorStyles.Bottom;
            btn5Cch.Anchor = AnchorStyles.Bottom;

            flowLayoutPanel1.Controls.Add(btn5ch);
            flowLayoutPanel1.Controls.Add(btn2ch);
            flowLayoutPanel1.Controls.Add(btn1ch);
            flowLayoutPanel1.Controls.Add(btn50Cch);
            flowLayoutPanel1.Controls.Add(btn20Cch);
            flowLayoutPanel1.Controls.Add(btn10Cch);
            flowLayoutPanel1.Controls.Add(btn5Cch);
        }
    }
}
