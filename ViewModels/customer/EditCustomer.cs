using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Production.enums;

namespace Production.ViewModels.customer
{
    public class EditCustomer
    {
          
            public int custID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Culture { get; set; }
            public string TimeZone { get; set; }
            public string Phone { get; set; }
            public string email { get; set; }
            public Channel? Channel { get; set; }
            public Gender? Gender { get; set; }
            public int budgetID { get; set; }
            public bool premium { get; set; }
            public bool cheap { get; set; }
            public bool luxury { get; set; }
 
       
    }
}