using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Production.Interface;
using Production.DAL;
using Production.Models;

namespace Production.services
{
    public class countryService : IcountryRepository 
    {
        private BusContext context;

        public countryService(BusContext context)
        {
            this.context = context;
        }

        public void InsertCountry(country coun)
        {
            context.country.Add(coun);
        }

        public void DeleteCountry(int countryID)
        {
            country coun = context.country.Find(countryID);
            context.country.Remove(coun);
        }

        public void UpdateCountry(country coun)
        {
         //   context.Entry(country).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}