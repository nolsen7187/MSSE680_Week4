using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using FFR;

public interface IEmployee
{
    void EmployeeSalesEdit();
}
public class EmployeeImpl : IEmployee
{
    public void EmployeeSalesEdit()
    {
        Console.WriteLine("EmployeeSalesEdit method in the EmployeeImpl:IEmployee accessed");
    }
}

