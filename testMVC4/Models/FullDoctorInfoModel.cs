using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testMVC4.Services;

namespace testMVC4.Models
{
    public class FullDoctorInfoModel
    {
        public FullDoctorInfoModel(DoctorModel dModel, UserModel uModel)
        {
            DoctorModel = dModel;
            UserModel = uModel;
        }
        public DoctorModel DoctorModel { get; set; }
        public UserModel UserModel { get; set; }
    }
}