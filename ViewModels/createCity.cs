using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Production.Models;

namespace Production.ViewModels
{
    public class createCity
    {
        public int cityID { get; set; }
        public string cityName { get; set; }
        public int countryId { get; set; }

        public virtual country country { get; set; }
        public IEnumerable<SelectListItem> GetCountry { get; set; }

    }
}