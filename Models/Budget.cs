using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Production.Models
{
    public class Budget
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int budgetID { get; set; }
        public int custID { get; set; }
        public bool premium { get; set; }
        public bool cheap { get; set; }
        public bool luxury { get; set; }
        public customer customer { get; set; }
    }
}