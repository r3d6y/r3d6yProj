using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testMVC4.Models;

namespace testMVC4.Services.Interfaces
{
    public interface INewsService
    {
        IEnumerable<News> List();
        void AddNews(NewsModel model);
        News GetNewsById(int id);
        void EditNews(NewsModel model);
        void DeleteNews(int id);
    }
}
