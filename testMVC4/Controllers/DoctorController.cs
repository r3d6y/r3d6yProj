using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testMVC4.Models;

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
            IList<FullDoctorInfoModel> model = services.UserService.GetDoctorsList();
            return View(model);
        }

    }
}
