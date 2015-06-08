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

        public void AddNews(NewsModel model)
        {
            News news = new News();
            news.Title = model.Title;
            news.Text = model.Text;
            newsRepository.Insert(ref news);
        }

        public News GetNewsById(int id)
        {
            return newsRepository.FirstOrDefault(x => x.Id == id);
        }

        public void EditNews(NewsModel model)
        {
            try
            {
                News news = newsRepository.FirstOrDefault(x => x.Id == model.Id);
                news.Text = model.Text;
                news.Title = model.Title;
                newsRepository.Update(news);
            }
            catch(Exception ex)
            {
                int a = 4;
            }
        }

        public void DeleteNews(int id)
        {
            var news = newsRepository.FirstOrDefault(x => x.Id == id);
            if (news != null)
                newsRepository.Delete(news);
        }
    }
}