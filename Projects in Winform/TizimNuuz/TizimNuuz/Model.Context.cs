﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TizimNuuz
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TizimEntities : DbContext
    {
        public TizimEntities()
            : base("name=TizimEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AlreadyWork> AlreadyWorks { get; set; }
        public virtual DbSet<CreateTimeTableList> CreateTimeTableLists { get; set; }
        public virtual DbSet<EduCoursesList> EduCoursesLists { get; set; }
        public virtual DbSet<RegistrationClientsUZMU> RegistrationClientsUZMUs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TeachersUZMU> TeachersUZMUs { get; set; }
        public virtual DbSet<TypePerson> TypePersons { get; set; }
        public virtual DbSet<WorksTypee> WorksTypees { get; set; }
    }
}
