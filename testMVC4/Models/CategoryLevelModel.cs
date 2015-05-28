using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testMVC4.Models
{
    public class CategoryLevelModel
    {
        public CategoryLevelModel()
        {

        }

        public CategoryLevelModel(CategoryLevel level)
        {
            Id = level.Id;
            Level = level.Level;
        }

        public long Id { get; set; }
        public string Level { get; set; }
    }
}