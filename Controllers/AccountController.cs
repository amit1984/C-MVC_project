using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Production.Models;
using Production.Repository;

namespace Production.Controllers
{
    public class AccountController : Controller
    {
        private GenericRepository<Account> counrepos;
        private UnitofWork unitOfWork = new UnitofWork();

        public ActionResult Index(string searchString)
        {
            var _account = unitOfWork.AccountRepository.Get();
            if (!String.IsNullOrEmpty(searchString))
            {
                var _filterAccount = _account.Where(p => p.FirstName == searchString);
                return View(_filterAccount.ToList());
            }
            else
            {
                return View(_account.ToList());
            }
            
        }

        //
        // GET: /Account/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Account/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Account/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {            
                var coun = new Account();
                coun.FirstName = collection["FirstName"].ToString();
                coun.LastName = collection["LastName"].ToString();
                coun.Phone = collection["Phone"].ToString();
                coun.TimeZone = collection["TimeZone"].ToString();
                coun.email = collection["email"].ToString();
                coun.Culture = collection["Culture"].ToString();
                unitOfWork.AccountRepository.Insert(coun);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Account/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Account/Edit/5

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
        // GET: /Account/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Account/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Guid _CurrentGuid;
                _CurrentGuid = Guid.NewGuid();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
