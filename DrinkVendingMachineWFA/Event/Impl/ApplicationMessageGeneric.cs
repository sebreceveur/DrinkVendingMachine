using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkVendingMachineWFA.Event.Impl
{
    class ApplicationMessageGeneric<T> : ApplicationMessage
    {

        public T Field { get; private set; }
        public ApplicationMessageGeneric(T field)
        {
            Field = field;
        }

    }
}
