﻿using System;
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

        public DoctorModel(DoctorInfo model)
        {
            Id = model.Id;
            WorkPhone = model.WorkPhone;
            Photo = model.Photo;
            Unit = new UnitModel(model.HospitalUnit);
            Cval = new DoctorCvalificationModel(model.DoctorCvalification);
        }

        public DoctorModel(IList<CategoryLevelModel> categories, IList<UnitModel> units)
        {
            Levels = categories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Level
            });
            Units = units.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Unit
            });
        }

        public long Id { get; set; }
        [Display(Name = "Рабочий телефон: ")]
        public int? WorkPhone { get; set; }
        public string Photo { get; set; }
        public int UnitId { get; set; }
        public int CvalId { get; set; }
        public int LocationId { get; set; }
        [Display(Name = "Категория врача: ")]
        public IEnumerable<SelectListItem> Levels { get; set; }
        [Display(Name = "Отделение: ")]
        public IEnumerable<SelectListItem> Units { get; set; }

        public UnitModel Unit { get; set; }
        public DoctorCvalificationModel Cval { get; set; }

        public int UserId { get; set; }
    }
}