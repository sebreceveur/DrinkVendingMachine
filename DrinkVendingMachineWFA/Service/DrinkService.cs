using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkVendingMachineWFA.Service
{
    class DrinkService : WebClientServiceBase
    {
        public DrinkService()
        {
            base.BaseUri += "/drink";
        }
    }
}
