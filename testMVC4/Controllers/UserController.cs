using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using testMVC4.Models;
using testMVC4.Repositories;
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
            if (ModelState.IsValid)
            {
                if (IsValid(user.Email, user.Password))
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

        [HttpPost]
        public ActionResult LoginAjax(string email, string password)
        {
            if (IsValid(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, false);
                ViewBag.UserName = email;
                var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                var JsonResult = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(true, settings),
                    ContentType = "application/json"
                };
                return JsonResult;
            }
            else
            {
                ModelState.AddModelError("", "Login data is incorrect.");
                var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                var JsonResult = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(false, settings),
                    ContentType = "application/json"
                };
                return JsonResult;
                
            }
            
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserModel user)
        {
            if (ModelState.IsValid)
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
            return RedirectToAction("Index", "Home");
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
            model.UserId = Convert.ToInt32(services.UserService.GetByEmail(Session["UserName"].ToString()).Id);
            services.UserService.AddDoctorInfo(model);

            //todo: add receptions for week
            services.ReceptionService.AddReceptionHoursForUser(model.UserId);


            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Administrate()
        {
            if (Session["UserName"] != null)
            {
                var user = services.UserService.GetByEmail(Session["UserName"].ToString());
                if (!user.is_admin)
                    return RedirectToAction("Index", "Home");

                return View();
            }
            else
                return RedirectToAction("Index", "Home");

            //return View();
        }

        [Authorize]
        public ActionResult DoctorsManage()
        {
            List<UserModel> allUsers = services.UserService.List().Select(u => new UserModel(u)).ToList();


            return View(allUsers);
        }

        [Authorize]
        public ActionResult NewsManage()
        {
            List<NewsModel> allNews = services.NewsService.List().Select(n => new NewsModel(n)).ToList();
            return View(allNews);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SetDoctorStatus(int id)
        {
            try
            {
                var user = new UserModel(services.UserService.GetById(id));
                if (user != null)
                {
                    user.IsDoctor = !user.IsDoctor;
                    //services.UserService.Update(user);
                    //services.UserService.Insert(user);
                    services.UserService.SetDoctor(user);
                }
                //BaseRepository<User> rep = new BaseRepository<User>();
                //var user = rep.FirstOrDefault(x => x.Id == id);
                //user.is_doctor = !user.is_doctor;
                //rep.Update(user);
            }
            catch (Exception ex)
            {

            }
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var JsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject("redirect", settings),
                ContentType = "application/json"
            };
            return JsonResult;
        }

        [Authorize]
        [HttpGet]
        public ActionResult ReceptionManage(int id)
        {
            //var user = services.UserService.GetById(id);
            var receptionHours = services.ReceptionService.GetReceptionByUserId(id).Select(x => new ReceptionModel(x)).ToList();
            
            return View(receptionHours);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ReceptionManage(List<ReceptionModel> model)
        {
            services.ReceptionService.UpdateReceptionsForUser(model);

            return RedirectToAction("DoctorManage", "User");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Profil()
        {
            var user = services.UserService.GetByEmail(Session["UserName"].ToString());
            return View(user);
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditProfil()
        {
            var user = new UserModel(services.UserService.GetByEmail(Session["UserName"].ToString()));
            return View(user);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditProfil(UserModel model)
        {
            services.UserService.UpdateUserProfil(model);
            return RedirectToAction("Profil", "User");
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditPacientProfile()
        {
            var user = new UserModel(services.UserService.GetByEmail(Session["UserName"].ToString()));
            var pacientProfil = new PacientModel(services.UserService.GetPacientInfoById((int)user.PacientInfo));
            return View(pacientProfil);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditPacientProfile(PacientModel model)
        {
            services.UserService.UpdatePacientProfil(model);
            return RedirectToAction("Profil", "User");
        }

        [Authorize]
        [HttpGet]
        public ActionResult OneReceptionManage(int id)
        {
            var receptionHour = new ReceptionModel(services.ReceptionService.GetReceptionById(id));
            //receptionHour.Time = time;
            //receptionHour.Duration = duration;
            //return RedirectToAction("ReceptionManage", "User");
            return View(receptionHour);
        }

        [Authorize]
        [HttpPost]
        public ActionResult OneReceptionManage(ReceptionModel model)
        {
            services.ReceptionService.EditReceptionHour(model);
            var userId = services.UserService.GetUserIdByDocId(model.DoctorId);
            return RedirectToAction("ReceptionManage", "User", new { id = userId });
        }

        #region private methods
        private bool IsValid(string email, string password)
        {
            bool isValid = false;
            var crypto = new PBKDF2();

            using (var db = new hospitalDBEntities1())
            {
                var user = db.User.FirstOrDefault(u => u.Email == email);

                if (user != null)
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