using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Production.DAL;
using Production.Models;
using Production.ViewModels.customer;

namespace Production.Repository
{
    public class UnitofWork : IDisposable
    {
        private BusContext context = new BusContext();
        private GenericRepository<country> countryRepository;
        private GenericRepository<city> cityRepository;
        private GenericRepository<Account> accountRepository;
        private GenericRepository<customer> customerRepository;
        private GenericRepository<Budget> budgetRepository;
      

        public GenericRepository<country> CountryRepository
        {
            get
            {

                if (this.countryRepository == null)
                {
                    this.countryRepository = new GenericRepository<country>(context);
                }
                return countryRepository;
            }
        }
        public GenericRepository<Account> AccountRepository
        {
            get
            {

                if (this.accountRepository == null)
                {
                    this.accountRepository = new GenericRepository<Account>(context);
                }
                return accountRepository;
            }
        }
        public GenericRepository<customer> CustomerRepository
        {
            get
            {

                if (this.customerRepository == null)
                {
                    this.customerRepository = new GenericRepository<customer>(context);
                }
                return customerRepository;
            }
        }
        public GenericRepository<city> CityRepository
        {
            get
            {

                if (this.cityRepository == null)
                {
                    this.cityRepository = new GenericRepository<city>(context);
                }
                return cityRepository;
            }
        }
        public GenericRepository<Budget> BudgetRepository
        {
            get
            {

                if (this.budgetRepository == null)
                {
                    this.budgetRepository = new GenericRepository<Budget>(context);
                }
                return budgetRepository;
            }
        }
    
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}