using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testMVC4.Models
{
    public class LocationModel
    {
        public LocationModel()
        {

        }

        public long Id { get; set; }
        public int Numb { get; set; }
        public int Floor { get; set; }
        public int UnitId { get; set; }
    }
}