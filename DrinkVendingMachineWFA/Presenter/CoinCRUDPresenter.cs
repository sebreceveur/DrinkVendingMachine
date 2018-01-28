using DrinkVendingMachineWFA.Event.Impl;
using DrinkVendingMachineWFA.Model;
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
        private readonly IWebClientService _coinService;

        public CoinCRUDPresenter(ICoinView coinView, IWebClientService coinService)
        {
            _coinCRUDView = coinView;
            _coinService = coinService;
            FillGrid();

            

            EventAggregator.Instance.Subscribe<ApplicationMessageGeneric<CoinStore>>(OnUpdated);
        }

        private void OnUpdated(ApplicationMessageGeneric<CoinStore> c)
        {
            _coinService.Post(c.Field);
        }

        public void FillGrid()
        {
            var coins = _coinService.Get();
            _coinCRUDView.SetDataGrid(coins);
           
        }
    }
}
