using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testMVC4.Models;
using testMVC4.Services;

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

        [Authorize]
        [HttpGet]
        public ActionResult EditDoctorsProfile()
        {
            var user = services.UserService.GetByEmail(Session["UserName"].ToString());
            var doctorInfo = new DoctorModel(services.UserService.GetDoctorById((int)user.DoctorInfo), services.UserService.GetCategories(), services.UserService.GetUnits());
            return View(doctorInfo);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditDoctorsProfile(DoctorModel model)
        {
            services.UserService.UpdateDoctorInfo(model);
            return RedirectToAction("Profil", "User");
        }

        [Authorize]
        [HttpGet]
        public ActionResult ShowReceptionHours()
        {
            var user = services.UserService.GetByEmail(Session["UserName"].ToString());
            var receptionHours = services.ReceptionService.GetReceptionByUserId((int)user.Id).Select(x => new ReceptionModel(x)).ToList();
            return View(receptionHours);
        }

        //[Authorize]
        //[HttpPost]
        //public ActionResult ShowReceptionHours()
        //{
        //    return View();
        //}

    }
}
