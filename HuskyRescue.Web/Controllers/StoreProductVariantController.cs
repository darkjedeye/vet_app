using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuskyRescue.Web.Controllers
{
    public class StoreProductVariantController : Controller
    {
        //
        // GET: /StoreProductVariant/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /StoreProductVariant/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /StoreProductVariant/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /StoreProductVariant/Create

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
        // GET: /StoreProductVariant/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /StoreProductVariant/Edit/5

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
        // GET: /StoreProductVariant/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /StoreProductVariant/Delete/5

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
