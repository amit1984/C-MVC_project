using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Production.Models
{
    public class BusLists
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BusListsID { get; set; }

        public string BusName { get; set; }
        public int BusNo { get; set; }
    }
}