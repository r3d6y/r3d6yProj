﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hospitalDBEntities1 : DbContext
    {
        public hospitalDBEntities1()
            : base("name=hospitalDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategoryLevel> CategoryLevel { get; set; }
        public virtual DbSet<DoctorInfo> DoctorInfo { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<HospitalUnit> HospitalUnit { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<PacientInfo> PacientInfo { get; set; }
        public virtual DbSet<ReceptionHour> ReceptionHour { get; set; }
        public virtual DbSet<ReceptionTicket> ReceptionTicket { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}