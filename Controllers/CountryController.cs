using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Production.DAL;
using Production.Models;
using Production.Interface;
using Production.Repository;

namespace Production.Controllers
{
    public class CountryController : Controller
    {
        //
        // GET: /Country/
      private GenericRepository<country> counrepos;
      private readonly IcountryRepository countryRepository;
      private UnitofWork unitOfWork = new UnitofWork();

      //public CountryController()
      //{
      //    this.countryRepository = new countryRepository(new BusContext());
      //}
     
        public CountryController(IcountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }



        public ActionResult Index(string searchString)
        {
            var _country = unitOfWork.CountryRepository.Get();
            if (!String.IsNullOrEmpty(searchString))
            {
                var _filterCountry = _country.Where(p => p.countryName == searchString);
                return View(_filterCountry.ToList());
            }
            else
            {
                return View(_country.ToList());
            }
           
        }

        //
        // GET: /Country/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Country/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Country/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
              
                BusContext bc = new BusContext();
                var coun = new country();
                coun.countryName = collection["countryName"].ToString();
                //unitOfWork.CountryRepository.Insert(coun);
                //unitOfWork.Save();
                countryRepository.InsertCountry(coun);
                countryRepository.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Country/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Country/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Country/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Country/Delete/5

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
