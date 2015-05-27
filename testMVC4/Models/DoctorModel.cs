using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testMVC4.Services
{
    public class DoctorModel
    {
        public DoctorModel()
        {

        }

        public long Id { get; set; }
        [Display(Name="Рабочий телефон: ")]
        public int? WorkPhone { get; set; }
        public string Photo { get; set; }
        public int UnitId { get; set; }
        public int CvalId { get; set; }
        public int LocationId { get; set; }
    }
}