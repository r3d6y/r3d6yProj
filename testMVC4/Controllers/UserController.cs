using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using testMVC4.Models;
using testMVC4.Services;

namespace testMVC4.Controllers
{
    public class UserController : BaseController
    {
        public UserController()
            : base(new Services.Services())
        {

        }   

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginModel user)
        {
            if(ModelState.IsValid)
            {
                if(IsValid(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    ViewBag.UserName = user.Email;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect.");
                }
            }
            return RedirectToAction("Index", "Home");//View("Index", "Home");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserModel user)
        {
            if(ModelState.IsValid)
            {
                Session["UserId"] = null;
                var userEmaiValid = services.UserService.GetByEmail(user.Email);
                if (userEmaiValid == null)
                {
                    var crypto = new PBKDF2();
                    var encrPass = crypto.Compute(user.Password);
                    user.Password = encrPass;
                    user.PasswordSalt = crypto.Salt;

                    var _user = services.UserService.Insert(user);
                    Session["UserId"] = _user.Id;
                    return RedirectToAction("RegistrationPacientStep", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Email уже используется");
                }
            }
            else
            {
                ModelState.AddModelError("", "Reg data invalid.");
            }
            return View();
        }

        [HttpGet]
        public ActionResult RegistrationPacientStep()
        {
            if (Session["UserId"] != null)
            {
                var userId = Session["UserId"];
                PacientModel model = new PacientModel();
                model.UserId = Convert.ToInt32(userId);
                return View(model);
                //return View("Index", "Home");
            }
            else
                return View();
        }

        [HttpPost]
        public ActionResult RegistrationPacientStep(PacientModel model)
        {
            services.UserService.AddPacientInfo(model);
            var user = services.UserService.GetById(model.UserId);
            LogInAfterRegister(new UserModel(user));
            
            Session["UserId"] = null;
            Session["UserName"] = user.Email;
            //return RedirectToAction("LogIn", "User");
            return View("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddDoctorInfo()
        {
            DoctorModel model = new DoctorModel(services.UserService.GetCategories(), services.UserService.GetUnits());
            //model.Levels = services.UserService.GetCategories();
            
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddDoctorInfo(DoctorModel model)
        {

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }

        #region private methods
        private bool IsValid(string email, string password)
        {
            bool isValid = false;
            var crypto = new PBKDF2();

            using(var db = new hospitalDBEntities())
            {
                var user = db.User.FirstOrDefault(u => u.Email == email);

                if(user != null)
                {
                    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                    { 
                        isValid = true;
                        Session["UserName"] = user.Email;
                    }
                }
            }
            return isValid;
        }

        private void LogInAfterRegister(UserModel user)
        {
            FormsAuthentication.SetAuthCookie(user.Email, false);
            ViewBag.Auth = true;
        }
        #endregion
    }
}