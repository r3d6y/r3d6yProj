using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testMVC4.Services
{
    public class DoctorCvalificationModel
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }
        public int LevelId { get; set; }
    }
}