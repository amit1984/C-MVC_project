using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Production.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Production.ViewModels.customer;

namespace Production.DAL
{
    public class BusContext:DbContext
    {
        public BusContext() : base("BusContext")
        {
        }
        
        public DbSet<BusLists> BusLists { get; set; }
        public DbSet<country> country { get; set; }
        public DbSet<city> city { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<customer> customer { get; set; }
        public DbSet<Budget> Budget { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BusContext>()); 
        }
    }
}