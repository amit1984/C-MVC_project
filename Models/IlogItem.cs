using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Production.Models
{
    public interface IlogItem
    {
          DateTime? Created { get; set; }
          Guid? CreatedBy { get; set; }
          DateTime? Changed { get; set; }
          Guid? ChangedBy { get; set; }
           
        
    }
}