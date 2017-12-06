using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuskyRescue.Web.Controllers
{
    public class StoreCartController : Controller
    {
        //
        // GET: /StoreCart/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /StoreCart/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /StoreCart/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /StoreCart/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /StoreCart/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /StoreCart/Edit/5

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
        // GET: /StoreCart/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /StoreCart/Delete/5

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
