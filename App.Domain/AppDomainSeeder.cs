using App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
  public  class AppDomainSeeder: DbMigrationsConfiguration<AppDomainContext>
    {
        public DateTime DateNow { get; set; } = DateTime.Now;
        public AppDomainSeeder()
        {
        }
        protected override void Seed(AppDomainContext context)
        {
            //EmployeeSeed(context);
            GenderSeeder(context);
            //EmployeeTaskSeeder(context);
        }

        //private void EmployeeSeed(AppDomainContext context)
        //{

        //    context.Employee.AddOrUpdate(data => data.Username, new Employee
        //    {
        //        FirstName = "Jason",
        //        LastName = "Gange",
        //        Username = "MyUsername",
        //        Department = "MIS Department",
        //        Gender = "Male",
        //        Birthday = DateNow.AddYears(-30),
        //        DateCreated = DateNow,
        //        CreatedBy = "Admin",
        //        IsActive = true,
        //        EmployeeAddress = new EmployeeAddress
        //        {
        //            Street = "Palay Street",
        //            Baranggay = "Tumana",
        //            City = "Marikina City",
        //            IsActive = true,
        //            DateCreated = DateNow,
        //            CreatedBy = "Admin"
        //        }
        //    });
        //    context.SaveChanges();
        //}
        //private void EmployeeTaskSeeder(AppDomainContext context)
        //{
        //    var employee = context.Employee.Where(e => e.EmployeeId == 1).FirstOrDefault();

        //    context.EmployeeTask.AddOrUpdate(data => data.EmployeeTaskName, new EmployeeTask
        //    {
        //        EmployeeId = employee.EmployeeId,
        //        EmployeeTaskName = "First Task",
        //        EmployeeTaskDetails = "Sample Details",
        //        DateCreated = DateNow,
        //        CreatedBy = employee.Username,
        //        IsActive = true
        //    });
        //    context.SaveChanges();
        //}
        private void GenderSeeder(AppDomainContext context)
        {
            context.Genders.AddOrUpdate(data => data.Name, new Gender
            {
               GenderId = 1,
               Name = "Male",
               Description = "Male"
            });

            context.Genders.AddOrUpdate(data => data.Name, new Gender
            {
                GenderId = 2,
                Name = "Female",
                Description = "Female"
            });

            context.SaveChanges();
        }
    }
}
