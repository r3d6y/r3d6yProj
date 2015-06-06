using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testMVC4.Models;

namespace testMVC4.Controllers
{
    public class NewsController : BaseController
    {
        //
        // GET: /News/

        public NewsController()
            : base(new Services.Services())
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddNews()
        {
            return View(new NewsModel());
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddNews(NewsModel model)
        {
            services.NewsService.AddNews(model);   
            return RedirectToAction("NewsManage", "User");
        }

        
        [HttpPost]
        [Authorize]
        public void EditNewsAjax(int id)
        {
            Session["EditNewsId"] = id;
            
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditNews()
        {
            int id = Convert.ToInt32(Session["EditNewsId"]);
            Session["EditNewsId"] = null;
            var news = new NewsModel(services.NewsService.GetNewsById(id));
            return View(news);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditNews(NewsModel model)
        {
            services.NewsService.EditNews(model);
            return RedirectToAction("NewsManage", "User");
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteNews(int id)
        {
            services.NewsService.DeleteNews(id);
            return RedirectToAction("NewsManage", "User");
        }
    }
}
