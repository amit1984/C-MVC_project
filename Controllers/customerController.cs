using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Production.Controllers;
using Production.enums;
using Production.ViewModels.customer;
using Production.Models;
using Production.Repository;
using Production.Interface;
using Production.services;

namespace Production.Controllers
{
    public class customerController : BaseController
    {
        private GenericRepository<customer> counrepos;
        private UnitofWork unitOfWork = new UnitofWork();
        private readonly ICustomerService custService;
     

      //public CountryController()
      //{
      //    this.countryRepository = new countryRepository(new BusContext());
      //}

        public customerController(ICustomerService custService)
        {
            this.custService = custService;
        }
        public ActionResult Index(string searchString)
        {
            var _customer = unitOfWork.CustomerRepository.Get();
            if (!String.IsNullOrEmpty(searchString))
            {
                var _filterCustomer = _customer.Where(p => p.FirstName == searchString);
                return View(_filterCustomer.ToList());
            }
            else
            {
                return View(_customer.ToList());
            }
        }

        //
        // GET: /customer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /customer/Create
      
        public ActionResult Create()
        {
            var model = new createCustomer();
            model.Genders =  GetEnumSelectList<Gender>();
            model.Channels = GetEnumSelectList<Channel>();
            return View(model);
        }
       
        //
        // POST: /customer/Create

        [HttpPost]
        public ActionResult Create(createCustomer model)
        {
            try
            {
                try
                {
                    var coun = new customer();
                    coun.FirstName = model.FirstName;
                    coun.LastName = model.LastName;
                    coun.Phone = model.Phone;
                    coun.TimeZone = model.TimeZone;
                    coun.email = model.email;
                    coun.Culture = model.Culture;
                    coun.password = loginService.GetMD5Hash(model.password);
                    coun.Gender = model.Gender.Value;
                    coun.Channel = model.Channel.Value;
                    unitOfWork.CustomerRepository.Insert(coun);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /customer/Edit/5

        public ActionResult Edit(int id)
        {
            EditCustomer ec = custService.editcustomer(id);
            return View(ec);
        }

        //
        // POST: /customer/Edit/5

        [HttpPost]
        public ActionResult Edit(EditCustomer model)
        {
            try
            {
                customer ec = new customer();
                ec = custService.getcustomer(model.custID);
                ec.custID = model.custID;
                ec.FirstName = model.FirstName;
                ec.LastName = model.LastName;
                ec.Gender = model.Gender;
                ec.Phone = model.Phone;
                ec.TimeZone = model.TimeZone;
                ec.email = model.email;

                Budget bg = new Budget();
                bg.premium = model.premium;
                bg.cheap = model.cheap;
                bg.luxury = model.luxury;
                bg.custID = model.custID;

                unitOfWork.CustomerRepository.Update(ec);
                if (custService.getBudget(model.custID))
                {
                    unitOfWork.BudgetRepository.Update(bg);
                }
                else
                {
                    unitOfWork.BudgetRepository.Insert(bg);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /customer/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /customer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
