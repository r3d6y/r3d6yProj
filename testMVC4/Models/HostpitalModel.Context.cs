﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hospitalDBEntities : DbContext
    {
        public hospitalDBEntities()
            : base("name=hospitalDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CategoryLevel> CategoryLevel { get; set; }
        public DbSet<DoctorCvalification> DoctorCvalification { get; set; }
        public DbSet<DoctorInfo> DoctorInfo { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<HospitalUnit> HospitalUnit { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<PacientInfo> PacientInfo { get; set; }
        public DbSet<ReceptionHour> ReceptionHour { get; set; }
        public DbSet<ReceptionTicket> ReceptionTicket { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
