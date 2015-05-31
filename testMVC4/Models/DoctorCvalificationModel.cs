using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testMVC4.Models;

namespace testMVC4.Services
{
    public class DoctorCvalificationModel
    {
        public DoctorCvalificationModel()
        {

        }
        public DoctorCvalificationModel(DoctorCvalification cval)
        {
            Id = cval.Id;
            CategoryName = cval.CategoryName;
            LevelId = Convert.ToInt32(cval.LevelId);
        }

        public long Id { get; set; }
        public string CategoryName { get; set; }
        public int LevelId { get; set; }
    }
}