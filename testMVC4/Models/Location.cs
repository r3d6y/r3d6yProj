//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testMVC4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Location
    {
        public Location()
        {
            this.DoctorInfo = new HashSet<DoctorInfo>();
        }
    
        public long Id { get; set; }
        public int Numb { get; set; }
        public Nullable<int> Floor { get; set; }
        public Nullable<long> UnitId { get; set; }
    
        public virtual ICollection<DoctorInfo> DoctorInfo { get; set; }
        public virtual HospitalUnit HospitalUnit { get; set; }
    }
}
