using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testMVC4.Models
{
    public class UnitModel
    {
        public UnitModel(HospitalUnit unit)
        {
            Id = unit.Id;
            Unit = unit.Unit;
        }

        public long Id { get; set; }
        public string Unit { get; set; }
    }
}