using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFR;
using System.Data;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Soap;


namespace Services
{
    public interface ICustomer
    {
        Customer CustomerAcquire(int id);
        void CustomerNew(Customer id);
        void CustomerUpdate(Customer id);
        void CustomerDelete(Customer id);

       // void CustomerListWrite(ArrayList customers);
        

    }
    public class CustomerImpl : ICustomer
    {
        //public string CustomerNew(int id);

        public void CustomerNew(Customer id)
        {
            Console.WriteLine("CustomerNew method in the CustomerImpl:ICustomer accessed");
            //return;
        }
        public void CustomerUpdate(Customer id)
        {
            Console.WriteLine("CustomerUpdate method in the CustomerImpl:ICustomer accessed");
            //return;
        }
        public void CustomerDelete(Customer id)
        {
            Console.WriteLine("CustomerDelete method in the CustomerImpl:ICustomer accessed");
            //return;
        }
        public Customer CustomerAcquire(int id)
        {
            return new Customer();
        }
        /*public Customer CustomerListWrite(ArrayList customers)
        {
            return new Customer();
        }*/
    }
    public class CustomerBinarySerializeImpl : ICustomer
    {
        public void CustomerNew(Customer id)
        {
            FileStream fileStream = new FileStream("Customer.bin", FileMode.Create, FileAccess.Write);
            IFormatter formatter = new BinaryFormatter();
            fileStream.Close();
            //Console.WriteLine("CustomerNew method in the CustomerImpl:ICustomer accessed");
            //return;
        }
        public void CustomerUpdate(Customer id)
        {
            Console.WriteLine("CustomerUpdate method in the CustomerImpl:ICustomer accessed");
            //return;
        }
        public void CustomerDelete(Customer id)
        {
            Console.WriteLine("CustomerDelete method in the CustomerImpl:ICustomer accessed");
            //return;
        }
        public Customer CustomerAcquire(int id)
        {
            FileStream fileStream = new FileStream("Customer.bin", FileMode.Open, FileAccess.Read);
            IFormatter formatter = new BinaryFormatter();
            Customer customer = formatter.Deserialize(fileStream) as Customer;
            fileStream.Close();
            return customer;
        }
        public ArrayList CustomerListWrite(ArrayList customers)
        {
            FileStream fileStream = new FileStream("Customers.bin", FileMode.Create, FileAccess.Write);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, customers);
            fileStream.Close();
            return customers;
        }
    }
}
