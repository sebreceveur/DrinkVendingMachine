using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkVendingMachineWFA.Service
{
    class CoinStorageService : WebClientServiceBase
    {
        public CoinStorageService()
        {
            base.BaseUri += "/coin";
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
