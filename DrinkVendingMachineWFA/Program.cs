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
            WebClientServiceBase coinService = new CoinStorageService();
            WebClientServiceBase drinkService = new DrinkService();

            //Views
            CoinCRUDView coinCRUD = new CoinCRUDView();
            DispenserView dispenserView = new DispenserView();
            CoinStorageView coinStorageView = new CoinStorageView();

            dispenserView.SetCoinStorageView(coinStorageView);

            //Presenters
            CoinCRUDPresenter coinCRUDPresenter = new CoinCRUDPresenter(coinCRUD, coinService);
            CoinStoragePresenter coinStoragePresenter = new CoinStoragePresenter(coinStorageView, coinService);
            DispenserPresenter dispenserPresenter = new DispenserPresenter(dispenserView, coinStoragePresenter, coinService, drinkService);
            

            //Main
            MainForm main = new MainForm(dispenserView, coinCRUD);

            

            Application.Run(main);
        }
    }
}
