//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testMVC4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DoctorCvalification
    {
        public DoctorCvalification()
        {
            this.DoctorInfo = new HashSet<DoctorInfo>();
        }
    
        public long Id { get; set; }
        public string CategoryName { get; set; }
        public Nullable<long> LevelId { get; set; }
    
        public virtual CategoryLevel CategoryLevel { get; set; }
        public virtual ICollection<DoctorInfo> DoctorInfo { get; set; }
    }
}
