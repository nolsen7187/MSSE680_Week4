using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using FFR;

public interface ISales
{
    void SalesItemBrowse();
    void SalesNew();
    void SalesCheckOut();
}
public class SalesImpl : ISales
{
    public void SalesItemBrowse()
    {
        Console.WriteLine("SalesItemBrowse method in the SalesImpl:ISales accessed");
    }
    public void SalesNew()
    {
        Console.WriteLine("SalesNew method in the SalesImpl:ISales accessed");
    }
    public void SalesCheckOut()
    {
        Console.WriteLine("SalesCheckOut method in the SalesImpl:ISales accessed");
    }
}
