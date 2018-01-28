using DrinkVendingMachineWFA.Service;
using DrinkVendingMachineWFA.View.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkVendingMachineWFA.Presenter
{
    class CoinCRUDPresenter
    {
        // View
        private readonly ICoinView _coinCRUDView;

        //Service
        private readonly WebClient _webClient;

        public CoinCRUDPresenter()
        {

        }

        public CoinCRUDPresenter(ICoinView coinView, WebClient webClient)
        {
            _coinCRUDView = coinView;
            _webClient = webClient;
            FillGrid();
        }

        public void FillGrid()
        {
            var coins = _webClient.GetRESTData("http://localhost/DrinkVendingMachine/api/coin");
            _coinCRUDView.SetDataGrid(coins);
           
        }
    }
}
