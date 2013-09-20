using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFR;
using System.Data;

namespace Services
{
    public interface ICustomer
    {
        Customer CustomerAcquire(int id);
        void CustomerNew(Customer id);
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

        public void CustomerNew(Customer id)
        {
            Console.WriteLine("CustomerNew method in the CustomerImpl:ICustomer accessed");
            return;
        }
        public Customer CustomerAcquire(int id)
        {
            return new Customer();
        }


    }
}
