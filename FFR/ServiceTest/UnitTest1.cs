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


            Customer createCustomer = Activator.CreateInstance<Customer>();
            createCustomer.CustomerId = 2;
            createCustomer.FirstName = "Nick";
            createCustomer.LastName = "Olsen";
            createCustomer.Address = "11320 Lovage Way";
            createCustomer.City = "Parker";
            createCustomer.State = "CO";
            createCustomer.Zip = "80134";
            createCustomer.Phone = "303-949-2695";
            createCustomer.Email = "jolsen@hotmail.com";

            var customerRepo = FFR.Service.CRUDRepositoryConcreteFactory.CRUD<Customer>();

            switch (1)
            {
                case 1://Create
                    customerRepo.Create(createCustomer);// = new DataRepository<Customer>();
                    break;
                case 2://Update
                    customerRepo.Update(createCustomer);
                    break;
                case 3://Delete
                    customerRepo.Delete(createCustomer);
                    break;
                default:
                    modifiedRepository = new DataRepository<Customer>();
                    break;
            }

            //customerRepo.Create(createCustomer);


            Console.WriteLine("Yeah Buddy");
            
        }
    }
}
