using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testMVC4.Models;

namespace testMVC4.Services
{
    public class DoctorModel
    {
        public DoctorModel()
        {

        }

        public DoctorModel(IList<CategoryLevelModel> categories)
        {
            Levels = categories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Level
                });
        }

        public long Id { get; set; }
        [Display(Name="Рабочий телефон: ")]
        public int? WorkPhone { get; set; }
        public string Photo { get; set; }
        public int UnitId { get; set; }
        public int CvalId { get; set; }
        public int LocationId { get; set; }
        [Display(Name="Категория врача: ")]
        public IEnumerable<SelectListItem> Levels { get; set; }
    }
}