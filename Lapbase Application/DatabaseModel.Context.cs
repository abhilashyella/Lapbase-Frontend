﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lapbase_Application
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class teamjEntities : DbContext
    {
        public teamjEntities()
            : base("name=teamjEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Calorie> Calories { get; set; }
        public virtual DbSet<Excercise> Excercises { get; set; }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientWeightData> PatientWeightDatas { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<subscription> subscriptions { get; set; }
        public virtual DbSet<Target> Targets { get; set; }
    }
}
