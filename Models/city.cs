using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Production.Models
{
    public class city
    {
       

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cityID { get; set; }
        public string cityName { get; set; }
        public int countryId { get; set; }

        public virtual country country { get; set; } 

    }
}