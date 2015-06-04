using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testMVC4.Models;
using testMVC4.Repositories;
using testMVC4.Services.Interfaces;

namespace testMVC4.Services
{
    public class NewsService : INewsService
    {
        private readonly BaseRepository<News> newsRepository;

        public NewsService()
        {
            newsRepository = new BaseRepository<News>();
        }

        public IEnumerable<News> List()
        {
            return newsRepository.ToList();
        }
    }
}