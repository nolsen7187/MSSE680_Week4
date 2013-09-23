using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFR;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Data.Entity;
using System.Configuration;
using System.Linq.Expressions;

namespace ServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UseCRUDFactoryRetrieveUsingRepository()
        {
            var customerRepo = FFR.Service.CRUDRepositoryConcreteFactory.CRUD<Customer>();

            List<Customer> customerList = customerRepo.GetAll().ToList<Customer>();
            Assert.IsTrue(customerList.Count > 0);
        }
        [TestMethod]
        public void UseCRUDFactoryandReturnARepositoryandCreateCustomer()
        {
            Int16 actionType = 1;

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
            //Factory Return Repository
            var customerRepo = FFR.Service.CRUDRepositoryConcreteFactory.CRUD<Customer>();
            //Simulating the business logic that would ultimately be getting called from a controller in the manner it would be called.
            switch (actionType)
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
                    customerRepo = new DataRepository<Customer>();
                    //Assert.AreEqual(savedCustomer.CustomerId, 1);
                    break;
            } //customerRepo.Create(createCustomer);
           // Console.WriteLine("Yeah Buddy");            
        }
        [TestMethod]
        public void UseCRUDFactoryandReturnARepositoryandUpdateItem()
        {
            Int16 actionType = 2;

            Item createItem = Activator.CreateInstance<Item>();
            createItem.ItemName = "FP Gray Turbo";
            createItem.Price = 1200;
            createItem.ItemCost = 550;
            createItem.ItemId = 2;
            var itemRepo = FFR.Service.CRUDRepositoryConcreteFactory.CRUD<Item>();

            itemRepo.Create(createItem);

            var deleteItemRepo = FFR.Service.CRUDRepositoryConcreteFactory.CRUD<Item>();
            Item deleteItem = (from d in deleteItemRepo.GetAll() where d.ItemId == 2 select d).Single();

            switch (actionType)
            {
                case 1://Create
                    deleteItemRepo.Create(deleteItem);// = new DataRepository<Customer>();
                    break;
                case 2://Update
                    deleteItemRepo.Update(deleteItem);
                    break;
                case 3://Delete
                    deleteItemRepo.Delete(deleteItem);
                    break;
                default:
                    deleteItemRepo = new DataRepository<Item>();
                    //Assert.AreEqual(savedCustomer.CustomerId, 1);
                    break;
            }
        }
        [TestMethod]
        public void UseCRUDFactoryandReturnARepositoryandDeleteItem()
        {
            Int16 actionType = 3;

            Item createItem = Activator.CreateInstance<Item>();
            createItem.ItemName = "FP Gray Turbo";
            createItem.Price = 1200;
            createItem.ItemCost = 550;
            createItem.ItemId = 2;
            var itemRepo = FFR.Service.CRUDRepositoryConcreteFactory.CRUD<Item>();

            itemRepo.Create(createItem);

            var deleteItemRepo = FFR.Service.CRUDRepositoryConcreteFactory.CRUD<Item>();
            Item deleteItem = (from d in deleteItemRepo.GetAll() where d.ItemId == 2 select d).Single();

            switch (actionType)
            {
                case 1://Create
                    deleteItemRepo.Create(deleteItem);// = new DataRepository<Customer>();
                    break;
                case 2://Update
                    deleteItemRepo.Update(deleteItem);
                    break;
                case 3://Delete
                    deleteItemRepo.Delete(deleteItem);
                    break;
                default:
                    deleteItemRepo = new DataRepository<Item>();
                    //Assert.AreEqual(savedCustomer.CustomerId, 1);
                    break;
            } 
        }
        [TestMethod]
        public void RetrieveUsingRepository()
        {
            var customerRepo = new DataRepository<Customer>();

            List<Customer> customerList = customerRepo.GetAll().ToList<Customer>();
            Assert.IsTrue(customerList.Count > 0);
        }
    }
}
