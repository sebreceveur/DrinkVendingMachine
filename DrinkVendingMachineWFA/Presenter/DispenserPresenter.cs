using DrinkVendingMachineWFA.Event.Impl;
using DrinkVendingMachineWFA.Helper;
using DrinkVendingMachineWFA.Model;
using DrinkVendingMachineWFA.Service;
using DrinkVendingMachineWFA.View.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkVendingMachineWFA.Presenter
{
    class DispenserPresenter
    {
        // View
        private readonly IDispenserView _dispenserView;
        private readonly ICoinStorageView _coinStorageView;

        //Service
        private readonly IWebClientService _coinService;

        public DispenserPresenter(IDispenserView dispenserView, ICoinStorageView coinStorageView, IWebClientService coinService)
        {
            _dispenserView = dispenserView;
            _coinService = coinService;
            _coinStorageView = coinStorageView;            

            FillDispenser();
            
            //EventAggregator.Instance.Subscribe<ApplicationMessageGeneric<Drink>>(OnUpdated);
        }

        private void FillDispenser()
        {
            var tmp = _coinService.Get();
            var drinks = JsonConvert.DeserializeObject<List<Drink>>(tmp.ToString());

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
