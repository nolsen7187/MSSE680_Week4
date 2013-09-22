using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFR;

namespace ServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UseCRUDFactoryPassingInActionAndRepositoryType()
        {
            var customerRepo = FFR.Service.CRUDRepositoryConcreteFactory.CRUD(1, "Customer");          

            Customer createCustomer = new Customer();
            createCustomer.CustomerId = 2;
            createCustomer.FirstName = "Nick";
            createCustomer.LastName = "Olsen";
            createCustomer.Address = "11320 Lovage Way";
            createCustomer.City = "Parker";
            createCustomer.State = "CO";
            createCustomer.Zip = "80134";
            createCustomer.Phone = "303-949-2695";
            createCustomer.Email = "jolsen@hotmail.com";

            customerRepo.Create(createCustomer);


            Console.WriteLine("Yeah Buddy");
            
        }
    }
}
