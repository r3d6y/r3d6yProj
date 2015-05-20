using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testMVC4.Services.Interfaces;

namespace testMVC4.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IService services;

        public BaseController(IService services)
        {
            this.services = services;
        }
    }
}