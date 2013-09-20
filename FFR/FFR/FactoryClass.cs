using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace FFR
{
    public class FactoryClass
    {
        public ICustomer CustomerNew() 
        {
            return new CustomerImpl();
        }
    }
}
