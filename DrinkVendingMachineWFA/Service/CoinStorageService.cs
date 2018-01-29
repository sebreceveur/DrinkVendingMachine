using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkVendingMachineWFA.Service
{
    class CoinStorageService : WebClientServiceBase
    {
        public override string BaseUri { get; protected set; }

        public CoinStorageService()
        {
            this.BaseUri = "http://localhost/DrinkVendingMachine/api/coin";
        }

        public override object Get()
        {
            return base.Get();
        }

        public override void Post(object postData)
        {
            base.Post(postData);
        }

    }
}
