using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testMVC4.Models;

namespace testMVC4.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public HomeController()
            : base(new Services.Services())
        {

        }

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

        [HttpGet]
        public ActionResult News()
        {
            IList<NewsModel> allNews = services.NewsService.List().Select(x => new NewsModel(x)).ToList();
            return View(allNews);
        }

        [HttpGet]
        public ActionResult OneNews(int id)
        {
            NewsModel model = new NewsModel(services.NewsService.GetNewsById(id));
            return View(model);
        }

    }
}
