using App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
   public class AppDomainContext: DbContext
    {
        public AppDomainContext() : base("name=connectionString")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }
        public DbSet<EmployeeTask> EmployeeTask { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<NavLink> NavLinks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Religion> Religions { get; set; }

    }
}
