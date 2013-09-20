using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFR;

namespace Services
{
    public interface ICustomer
    {
        //CustomerId customerId;
        void CustomerNew(int id);
        //void CustomerEdit();
        //void CustomerDelete();
        //string GetCustomer(int id);
    }
    public interface ISales
    {
        void SalesItemBrowse();
        void SalesNew();
        void SalesCheckOut();
    }
    public class CustomerImpl : ICustomer
    {
        //public string CustomerNew(int id);

        public void CustomerNew(int id)
        {
            return;
        }

    }
}
