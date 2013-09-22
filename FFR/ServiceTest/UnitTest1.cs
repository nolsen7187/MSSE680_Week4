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
            Console.WriteLine("Yeah Buddy");
            
        }
    }
}
