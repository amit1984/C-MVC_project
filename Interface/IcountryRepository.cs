using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production.Models;

namespace Production.Interface
{
  public  interface IcountryRepository
    {
        void InsertCountry(country coun);
        void DeleteCountry(int countryID);
        void UpdateCountry(country student);
        void Save();
    }
}
