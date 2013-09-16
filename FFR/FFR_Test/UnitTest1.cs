using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Linq;
using FFR;
using System.Collections.Generic;
using System.Collections;

using System.Data.Entity;
using System.Configuration;
namespace FFR_Test
{

    [TestClass]
    public class UnitTest1
    {
        /*[TestMethod]
        public void AddCustomerandSaleHeader()
        {
            FFREntities ffrDb = new FFREntities();

            Customer customer = new Customer();
            customer.CustomerId = 1;
            customer.FirstName = "Nick";
            customer.LastName = "Olsen";
            customer.City = "Parker";
            customer.State = "CO";
            customer.Zip = "80134";
            //Need to Add Street Name and Suite Fields
            customer.Address = customer.FirstName + " " + customer.LastName + "11321 Lovage Way " + customer.City + ", " + customer.State + " " + customer.Zip;
            customer.Phone = "3037181336";
            customer.Email = "nolsen@regis.edu";

            ffrDb.Customers.Add(customer);
            ffrDb.SaveChanges();

            SalesHeader salesHeader = new SalesHeader();

            salesHeader.CustomerId = customer.CustomerId;
            salesHeader.SalesStatus = "Open";
            salesHeader.OrderSalesBalance = 50;
            salesHeader.OrderTaxAmount = 5;
            salesHeader.OrderTotal = salesHeader.OrderSalesBalance + salesHeader.OrderTaxAmount;

            ffrDb.SalesHeaders.Add(salesHeader);
            ffrDb.SaveChanges();
        }
        [TestMethod]
        public void ReadDB()
        {
            FFREntities ffrDb = new FFREntities();

            Customer savedCustomer = (from d in ffrDb.Customers where d.CustomerId == 1 select d).Single();

            Assert.AreEqual(savedCustomer.CustomerId, 1);
        }
        [TestMethod]
        public void DeleteSalesHeader()
        {
            FFREntities ffrDb = new FFREntities();

            SalesHeader salesHeader = new SalesHeader();
            salesHeader.SalesId = 1;
            salesHeader.SalesStatus = "Delete";
            salesHeader.OrderSalesBalance = 50;
            salesHeader.OrderTaxAmount = 5;
            salesHeader.OrderTotal = salesHeader.OrderSalesBalance + salesHeader.OrderTaxAmount;

            ffrDb.SalesHeaders.Add(salesHeader);
            ffrDb.SaveChanges();

            SalesHeader deleteSalesHeader = (from d in ffrDb.SalesHeaders where d.SalesId == 1 select d).Single();
            ffrDb.SalesHeaders.Remove(deleteSalesHeader);
            ffrDb.SaveChanges();
        }
        [TestMethod]
        public void UpdateSalesHeader()
        {
            FFREntities ffrDb = new FFREntities();

            SalesHeader salesHeader = new SalesHeader();
            salesHeader.SalesId = 2;
            salesHeader.CustomerId = 1;
            salesHeader.SalesStatus = "Update";
            salesHeader.OrderSalesBalance = 50;
            salesHeader.OrderTaxAmount = 5;
            salesHeader.OrderTotal = salesHeader.OrderSalesBalance + salesHeader.OrderTaxAmount;

            ffrDb.SalesHeaders.Add(salesHeader);
            ffrDb.SaveChanges();

            SalesHeader updateSalesHeader = (from d in ffrDb.SalesHeaders where d.SalesId == 2 select d).Single();
            updateSalesHeader.SalesStatus = "Record has been updated!";
            ffrDb.SaveChanges();
        }*/
        [TestMethod]
        public void CreateCustomerUsingRepository()
        {
            var customerRepo = new DataRepository<Customer>();

            Customer createCustomer = new Customer();
            createCustomer.FirstName = "Jackie";
            createCustomer.LastName = "Olsen";
            createCustomer.Address = "11320 Lovage Way";
            createCustomer.City = "Parker";
            createCustomer.State = "CO";
            createCustomer.Zip = "80134";
            createCustomer.Phone = "303-949-2695";
            createCustomer.Email = "jolsen@hotmail.com";

            customerRepo.Create(createCustomer);
        }
        
        [TestMethod]
        public void CreateItemUsingRepository()
        {
            var itemRepo = new DataRepository<Item>();

            Item createItem = new Item();
            createItem.ItemName = "FP Green Turbo";
            createItem.Price = 800;
            createItem.ItemCost = 350;

            itemRepo.Create(createItem);
        }
        [TestMethod]
        public void CreateSalesHeaderUsingRepository()
        {
            var SalesHeaderRepo = new DataRepository<SalesHeader>();

            SalesHeader createSalesHeader = new SalesHeader();
            createSalesHeader.CustomerId = 0;
            createSalesHeader.OrderSalesBalance = 800;
            createSalesHeader.OrderTaxAmount = 100;
            createSalesHeader.OrderTotal = 900;

            SalesHeaderRepo.Create(createSalesHeader);
        }
        [TestMethod]
        public void CreateSalesItemUsingRepository()
        {
            var SalesItemRepo = new DataRepository<SalesItem>();

            SalesItem createSalesItem = new SalesItem();
            createSalesItem.ItemId = 0;
            createSalesItem.ItemName = "FP Green Turbo";
            createSalesItem.Price = 800;
            createSalesItem.Qty = 1;
            createSalesItem.LineAmount = 800;

            SalesItemRepo.Create(createSalesItem);
        } 
        //Build list of customers from customer table in the FFR databse and provide a true value if list is greater than zero.
        [TestMethod]
        public void RetrieveUsingRepository()
        {
            var customerRepo = new DataRepository<Customer>();

            List<Customer> customerList = customerRepo.GetAll().ToList<Customer>();
            Assert.IsTrue(customerList.Count > 0);
        }
        //Update an Item in the FFR db Context
        [TestMethod]
        public void UpdateItemUsingRepository()
        {
            var itemRepo = new DataRepository<Item>();

            Item updateItem = new Item();
            updateItem.ItemId = 0;
            updateItem.Price = 1000;
            updateItem.ItemCost = 450;

            itemRepo.Update(updateItem);
        }
        //Update an Item in the FFR db Context
        [TestMethod]
        public void DeleteItemUsingRepository()
        {
            var itemRepo = new DataRepository<Item>();


            Item createItem = new Item();
            createItem.ItemName = "FP Gray Turbo";
            createItem.Price = 1200;
            createItem.ItemCost = 550;
            createItem.ItemId = 2;

            itemRepo.Create(createItem);
            itemRepo.Dispose();

            var deleteItemRepo = new DataRepository<Item>();
            //tried to look up specific record wanting to be deleted by using the getbyspecifickey method
            //I could grab the query but could not figure out a way to manipulate the query to delete the selected record.
            //IQueryable Query = deleteItemRepo.GetBySpecificKey("ItemId", 2);
            //string sqlClause = Query.ToString();
            //DbContext localContext;
            //localContext = new DbContext(ConfigurationManager.ConnectionStrings["FFREntities"].ConnectionString);
            //localContext.Database.ExecuteSqlCommand(String.Format("DELETE {0}", sqlClause));
            //List<Item> myList = deleteItemRepo.GetBySpecificKey("ItemId", 2);

            Item deleteItem = (from d in deleteItemRepo.GetAll() where d.ItemId == 2 select d).Single();
            //string sqlClause = Query.ToString();
            //deleteItemRepo.Delete(Query);
            //deleteItem.ItemId = 2;
            deleteItemRepo.Delete(deleteItem);
            deleteItemRepo.Dispose();
        }
    }
}
