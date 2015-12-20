using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production.Models;
using Production.ViewModels.customer;

namespace Production.Interface
{
   public  interface ICustomerService
    {
        EditCustomer editcustomer(int id);
        customer getcustomer(int id);
        bool getBudget(int id);
        bool checkCustomer(string username, string password);
        int getCustomerID(string username, string password);
    }
}
