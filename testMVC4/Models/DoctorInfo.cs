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
    
    public partial class DoctorInfo
    {
        public DoctorInfo()
        {
            this.History = new HashSet<History>();
            this.ReceptionHour = new HashSet<ReceptionHour>();
            this.ReceptionTicket = new HashSet<ReceptionTicket>();
        }
    
        public long Id { get; set; }
        public Nullable<int> WorkPhone { get; set; }
        public string Photo { get; set; }
        public Nullable<long> UnitId { get; set; }
        public Nullable<long> CvalId { get; set; }
        public Nullable<long> LocationId { get; set; }
    
        public virtual DoctorCvalification DoctorCvalification { get; set; }
        public virtual Location Location { get; set; }
        public virtual HospitalUnit HospitalUnit { get; set; }
        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<ReceptionHour> ReceptionHour { get; set; }
        public virtual ICollection<ReceptionTicket> ReceptionTicket { get; set; }
    }
}