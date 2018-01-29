using DrinkVendingMachineWFA.Model;
using DrinkVendingMachineWFA.Service;
using DrinkVendingMachineWFA.View.Contract;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DrinkVendingMachineWFA.Presenter
{
    class CoinStoragePresenter
    {
        // View
        private readonly ICoinStorageView _coinStorageView;

        //Service
        private readonly IWebClientService _coinService;

        public CoinStoragePresenter(ICoinStorageView coinStorageView, IWebClientService coinService)
        {
            _coinStorageView = coinStorageView;
            _coinService = coinService;
            FillStorage();

            //EventAggregator.Instance.Subscribe<ApplicationMessageGeneric<CoinStore>>(OnUpdated);
        }

        public void FillStorage()
        {            
            List<CoinStore> coins = JsonConvert.DeserializeObject<List<CoinStore>>(
                _coinService.Get().ToString());

            var dict = new Dictionary<decimal, int>();

            foreach(var item in coins)
            {
                dict.Add(item.Value, item.Quantity);
            }

            _coinStorageView.RefreshCoinStorage(dict);
        }

       
    }
}
