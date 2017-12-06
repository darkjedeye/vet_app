using System;
using System.Data.Services.Client;
using System.Linq;
using System.Web.Mvc;
using AnimalRescue.Web.Helpers;
using AnimalRescue.Web.Properties;
using AnimalRescue.Web.ViewModel;
using AutoMapper;
using System.Transactions;
using AnimalRescue.Services;
using System.Collections.Generic;
using System.Collections;

namespace AnimalRescue.Web.Controllers
{
    public class EventAttendeeController : Controller
    {
        //
        // GET: /EventAttendee/

        public ActionResult Index()
        {
            return View();
        }

		

    }
}
