using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testMVC4.Services;

namespace testMVC4.Models
{
    public class FullDoctorInfoModel
    {
        public FullDoctorInfoModel(DoctorModel dModel, UserModel uModel, IEnumerable<ReceptionModel> rModel)
        {
            DoctorModel = dModel;
            UserModel = uModel;
            ReceptionModel = rModel;
        }
        public DoctorModel DoctorModel { get; set; }
        public UserModel UserModel { get; set; }
        public IEnumerable<ReceptionModel> ReceptionModel { get; set; }
    }
}