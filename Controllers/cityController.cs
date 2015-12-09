using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Production.DAL;
using Production.Models;
using Production.Interface;
using Production.Repository;
using Production.ViewModels;


namespace Production.Controllers
{
    public class cityController : Controller
    {
        private GenericRepository<city> counrepos;
        private readonly IcountryRepository countryRepository;
        private UnitofWork unitOfWork = new UnitofWork();
        BusContext bc = new BusContext();

        public ActionResult Index(string searchString)
        {
            IEnumerable<ListCity> model = null;
            var _city = unitOfWork.CityRepository.Get();
            if (!String.IsNullOrEmpty(searchString))
            {
                var _filterCity = _city.Where(p => p.cityName == searchString);
                return View(_filterCity.ToList());
            }
            else
            {
                model = (from c in bc.city
                          join m in bc.country on c.countryId equals m.countryID
                          select new ListCity { cityID= c.cityID, cityName = c.cityName, countryName = m.countryName });
              
                                                 
                return View(model);
            }
            
        }

        private IEnumerable<SelectListItem> GetCountries()
        {
            
            var countries = bc.country.Select(x=>
                        new SelectListItem
                        {
                            Value = Convert.ToString(x.countryID),
                            Text = x.countryName
                        });
            
            return new SelectList(countries, "Value", "Text");
        }

      

        //
        // GET: /city/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /city/Create
        public JsonResult GetCountry()
        {
            var CountryList = bc.country.ToList();
            //var _country = unitOfWork.CountryRepository.Get();

            var con =  bc.country.Select(x => new { x.countryID, x.countryName }).ToList();
            return this.Json(con, JsonRequestBehavior.AllowGet);
        }  
        public ActionResult Create()
        {
            // createCity cc = new createCity();
            // var countries = bc.country.Select(x=>
            //            new SelectListItem
            //            {
            //                Value = Convert.ToString(x.countryID),
            //                Text = x.countryName
            //            });
            //cc.GetCountry = countries.AsEnumerable();
            return View();
        }

        //
        // POST: /city/Create

        [HttpPost]
        public ActionResult Create(createCity model)
        {
            try
            {

                
                var city = new city();
                city.cityName = model.cityName;
                city.countryId = model.countryId;
                unitOfWork.CityRepository.Insert(city);
                unitOfWork.Save();
               
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /city/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /city/Edit/5

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
        // GET: /city/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /city/Delete/5

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
