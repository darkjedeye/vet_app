using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuskyRescue.Web.Controllers
{
    public class StoreProductController : Controller
    {
        //
        // GET: /StoreProduct/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /StoreProduct/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /StoreProduct/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /StoreProduct/Create

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
        // GET: /StoreProduct/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /StoreProduct/Edit/5

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
        // GET: /StoreProduct/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /StoreProduct/Delete/5

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
