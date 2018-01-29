using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkVendingMachineWFA.Service
{
    interface IWebClientService
    {
        object Get();

        object Get(int id);

        void Post(object postData);

    }
}
