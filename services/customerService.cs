using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Production.Models;
using Production.Repository;
using Production.ViewModels.customer;
using Production.Interface;

namespace Production.services
{
    public class customerService : ICustomerService
    {
        private UnitofWork unitOfWork = new UnitofWork();

        public EditCustomer editcustomer(int id)
        {
            EditCustomer model = new EditCustomer();
            IEnumerable<customer> _filterCustomer = unitOfWork.CustomerRepository.Get().Where(p => p.custID == id);
            IEnumerable<Budget> _filterBudget = unitOfWork.BudgetRepository.Get().Where(p => p.custID == id);

            model.custID = _filterCustomer.First().custID;
            model.FirstName = _filterCustomer.First().FirstName;
            model.LastName = _filterCustomer.First().LastName;
            model.Culture = _filterCustomer.First().Culture;
            model.TimeZone = _filterCustomer.First().TimeZone;
            model.Phone = _filterCustomer.First().Phone;
            model.email = _filterCustomer.First().email;
            model.Gender = _filterCustomer.First().Gender;
            model.Channel = _filterCustomer.First().Channel;

            if (_filterBudget.Any())
            {
                model.budgetID = _filterBudget.First().budgetID;
                model.luxury = _filterBudget.First().luxury;
                model.cheap = _filterBudget.First().cheap;
                model.premium = _filterBudget.First().premium;
            }
            return (model);
        }

        public customer getcustomer(int id)
        {
            IEnumerable<customer> _filterCustomer = unitOfWork.CustomerRepository.Get().Where(p => p.custID == id);
            return (_filterCustomer.First());
        }
        public bool getBudget(int id)
        {
            IEnumerable<Budget> _filterBudget = unitOfWork.BudgetRepository.Get().Where(p => p.custID == id);
            if (_filterBudget.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}