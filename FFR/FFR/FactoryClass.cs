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
        //The only visible operations available from the business layer are implementations declared in an interface, 
        //if they are not specifically declared there, they are unaccessible!
        public ICustomer CustomerNew() 
        {
            return new CustomerImpl();
        }
    }
}
