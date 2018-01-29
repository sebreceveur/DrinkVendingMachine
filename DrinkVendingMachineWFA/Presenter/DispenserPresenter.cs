using DrinkVendingMachineWFA.Event.Impl;
using DrinkVendingMachineWFA.Helper;
using DrinkVendingMachineWFA.Model;
using DrinkVendingMachineWFA.Service;
using DrinkVendingMachineWFA.View.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DrinkVendingMachineWFA.Presenter
{
    class DispenserPresenter
    {
        private List<CoinStore> _coinsInserted;
        private Drink _selectedDrink;
        private List<Drink> _drink;

        // View
        private readonly IDispenserView _dispenserView;
       // private readonly ICoinStorageView _coinStorageView;

        //Service
        private readonly IWebClientService _coinService;
        private readonly IWebClientService _drinkService;

        //sub Presenter
        private readonly CoinStoragePresenter _coinStoragePresenter;

        public DispenserPresenter(IDispenserView dispenserView, CoinStoragePresenter coinStoragePresenter, IWebClientService coinService, IWebClientService drinkService)
        {
            _dispenserView = dispenserView;
            _coinService = coinService;
            _drinkService = drinkService;
            //_coinStorageView = coinStorageView;
            _coinStoragePresenter = coinStoragePresenter;

            _coinsInserted = new List<CoinStore>();
            FillDispenser();

            //subscriptions
            EventAggregator.Instance.Subscribe<ApplicationMessageGeneric<CoinStore>>(OnCoinSelected);
            EventAggregator.Instance.Subscribe<ApplicationMessageGeneric<Drink>>(OnDrinkSelected);

            dispenserView.Cancel += OnCancel;
            dispenserView.Order += OnOrdering;
  
        }

        private void OnCancel(Object send, EventArgs args)
        {
            _coinsInserted = new List<CoinStore>();
            _selectedDrink = null;

            _dispenserView.WriteMessage($"Order cancel, don't forget to take back your money");
        }

        private void OnOrdering(object sender, EventArgs args)
        {
            Order order = new Order()
            {
                coinInserted = _coinsInserted,
                selectedDrinkCan = _selectedDrink
            };

            Delivery delivery = ((DrinkService)_drinkService).PostOrder(order);

            if(delivery!= null && delivery.ErrorMessage == null)
            {
                string tmp = delivery.Coins[0].ToString();
                for (int i = 1; i < delivery.Coins.Count; i++)
                {
                    tmp += ", " + delivery.Coins[i].ToString();
                }

                _dispenserView.WriteMessage($"Here is you change: ({tmp}) and your {delivery.Drink.Description}");
                _coinsInserted = new List<CoinStore>();
                _selectedDrink = null;

                FillDispenser();
                _coinStoragePresenter.FillStorage(); // refresh

            }
            else if(delivery.ErrorMessage != null)
            {
                _dispenserView.WriteMessage(delivery.ErrorMessage);
            }

        }

        private void OnCoinSelected(ApplicationMessageGeneric<CoinStore> c)
        {
            _coinsInserted.Add(c.Field);

            string tmp = _coinsInserted[0].Value.ToString();
            for(int i = 1; i < _coinsInserted.Count; i++)
            {
                tmp += ", " + _coinsInserted[i].Value; 
            }

            _dispenserView.WriteMessage($"Coins inserted: ({tmp})");
        }

        private void OnDrinkSelected(ApplicationMessageGeneric<Drink> d)
        {
            _selectedDrink = d.Field;

            if(_drink!=null && _drink.Count > 0)
            {
                var drink = _drink.Where(a => a.Code == d.Field.Code).First();
                _selectedDrink = drink;
                _dispenserView.WriteMessage($"You are choosing: {drink.Description}");
            }

        }

        private void FillDispenser()
        {
            var tmp = _drinkService.Get();
            var drinks = JsonConvert.DeserializeObject<List<Drink>>(tmp.ToString());
            _drink = drinks;
            List<DrinkButton> buttons = new List<DrinkButton>();

            foreach(var item in drinks)
            {
                buttons.Add(new DrinkButton() { Width = 60,
                    Height = 100,
                    Text = item.Code + " " + item.Price,
                    Code = item.Code,
                    BackColor = ColorTranslator.FromHtml(item.Color),
                    Margin = new System.Windows.Forms.Padding(0, 0, 15, 40)
                });
            }

            if(buttons.Count > 0)
            {
                _dispenserView.RefreshDispenser(buttons);
            }            
        }

        private void OnUpdated(ApplicationMessageGeneric<Drink> d)
        {
            _coinService.Post(d.Field);
        }

    }
}
