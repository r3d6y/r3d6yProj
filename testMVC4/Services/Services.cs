﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testMVC4.Services.Interfaces;

namespace testMVC4.Services
{
    public class Services: IService
    {
        public Services()
        {

        }

        private IUserService userService;
        private INewsService newsService;

        public IUserService UserService
        {
            get
            {
                return userService = userService ?? new UserService();
            }
        }

        public INewsService NewsService
        {
            get
            {
                return newsService = newsService ?? new NewsService();
            }
        }
    }
}