﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testMVC4.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Var1 = "ololo";
            return View();
        }
        public ActionResult AboutUs() {
            return View(); 
        }
        public ActionResult Contacts()
        {
            return View();
        }

        public ActionResult News()
        {

            return View();
        }

        public ActionResult OneNews()
        {
            return View();
        }

    }
}
