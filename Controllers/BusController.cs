using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Production.Models;
using Production.DAL;

namespace Production.Controllers
{
    public class BusController : Controller
    {
        //
        // GET: /Bus/
        BusContext bc = new BusContext();
        public ActionResult Index()
        {
            var bus = from b in bc.BusLists
                      select b;

            return View(bus.ToList());
        }

        //
        // GET: /Bus/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Bus/Create

        public ActionResult Create()
        {
            var BusLis = new BusLists();
            return View(BusLis);
        }

        //
        // POST: /Bus/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
             
                // TODO: Add insert logic here
                var bus = new BusLists();
            //    bus.ID = 1;
                bus.BusName = collection["BusName"].ToString();
                bus.BusNo = Convert.ToInt32(collection["BusNo"]);
                bc.BusLists.Add(bus);
                bc.SaveChanges();

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        //
        // GET: /Bus/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Bus/Edit/5

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
        // GET: /Bus/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Bus/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BusLists bus = bc.BusLists.Find(id);
                if (bus == null)
                {
                    return HttpNotFound();
                }
                bc.BusLists.Remove(bus);
                bc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
