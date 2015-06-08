using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testMVC4.Models
{
    public class NewsModel
    {
        public NewsModel()
        {

        }

        public NewsModel(News model)
        {
            Id = model.Id;
            Title = model.Title;
            Text = model.Text;
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }

}