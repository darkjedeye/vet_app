﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuskyRescue.Web.Controllers
{
    public class StoreOrderController : Controller
    {
        //
        // GET: /StoreOrder/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /StoreOrder/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /StoreOrder/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /StoreOrder/Create

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
        // GET: /StoreOrder/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /StoreOrder/Edit/5

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
        // GET: /StoreOrder/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /StoreOrder/Delete/5

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
