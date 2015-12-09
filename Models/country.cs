using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Production.Models
{
    public class country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int countryID { get; set; }
        public string  countryName { get; set; }
        public virtual ICollection<city> city { get; set; }
    }
}