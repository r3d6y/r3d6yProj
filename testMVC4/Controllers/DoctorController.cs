using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testMVC4.Controllers
{
    public class DoctorController : BaseController
    {
        //
        // GET: /Doctor/
        public DoctorController()
            : base(new Services.Services())
        {

        }   
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDoctors()
        {
            
            return View();
        }

    }
}
