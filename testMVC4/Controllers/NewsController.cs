using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testMVC4.Models;

namespace testMVC4.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddNews()
        {
            return View(new NewsModel());
        }

        [HttpPost]
        public ActionResult AddNews(NewsModel model)
        {
            return RedirectToAction("NewsManage", "User");
        }

    }
}
