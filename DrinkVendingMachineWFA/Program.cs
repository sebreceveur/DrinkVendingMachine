using DrinkVendingMachineWFA.Presenter;
using DrinkVendingMachineWFA.Service;
using DrinkVendingMachineWFA.View.Contract;
using DrinkVendingMachineWFA.View.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrinkVendingMachineWFA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Services (Call to the web API)
            WebClient webclient = new WebClient();

            //Views
            CoinCRUDView coinCRUD = new CoinCRUDView();

            //Presenters
            CoinCRUDPresenter coinCRUDPresenter = new CoinCRUDPresenter(coinCRUD, webclient);


            //Main
            MainForm main = new MainForm(coinCRUD);

            Application.Run(main);
        }
    }
}
