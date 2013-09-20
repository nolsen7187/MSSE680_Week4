using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFR
{
    public class Class
    {
    }
    namespace Domain
    {

    }
    namespace Business
    {

    }
    namespace Presentation
    {

    }
    namespace Service
    {
        public interface ICustomer
        {
            CustomerId customerId;
            void CustomerNew();
            void CustomerEdit();
            void CustomerDelete();
        }
        public interface ISales
        {
            void SalesItemBrowse();
            void SalesNew();
            void SalesCheckOut();
        }

    }
}
