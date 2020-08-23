using App.Domain;
using App.Domain.Models;
using App.Models.DTO.Student;
using App.Services.Utilities;
using Infrastructure.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(
            AppDomainContext context
            ) : base(context)
        {
        }

        public Student GetById(int id)
        {
            return GetAll.FirstOrDefault(a => a.StudentId == id);
        }

        public StudentDetailsDTO GetDetails(int studentId)
        {
            var result = GetAll.Where(x => x.StudentId == studentId).Select(a => new StudentDetailsDTO
            {
               StudentId = a.StudentId,
               StudentNo = a.StudentNo,
               LastName = a.LastName,
               FirstName = a.FirstName,
               MiddleName = a.MiddleName,
               Address = a.Address,
               GenderId = a.GenderId,
               IsPaid = a.IsPaid,
               Birthday = a.Birthday,
               YearLevel = a.YearLevel,
               SchoolAttendedHistory = a.SchoolAttendedHistory,
               ContactNumber = a.ContactNumber,
               Remarks = a.Remarks
            }).FirstOrDefault();
            return result;
        }

        public override void InsertOrUpdate(Student entity)
        {
            if (entity.StudentId.Equals(0))
            {
                this.Context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                this.Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void InsertOrUpdate(Student entity, int appUserId)
        {
            if (entity.StudentId.Equals(0))
            {
                this.Context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                this.Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public IPagedList<SearchStudentDTO> SearchStudent(StudentFilter filter)
        {
            var data = GetData(filter);

            filter.FilteredRecordCount = data.Count();

            var dataDTO = data.Select(a => new SearchStudentDTO
            {
                StudentId = a.StudentId,
                StudentNo = a.StudentNo,
                LastName = a.LastName,
                FirstName = a.FirstName,
                MiddleName = a.MiddleName,
                Birthday = a.Birthday,
                Address = a.Address,
                Gender = a.Gender.Description,
                IsPaid = a.IsPaid ? "Yes":"No",
                YearLevel = a.YearLevel.ToString(),
                Remarks = a.Remarks,
                CreatedOn = a.CreatedOn,
                CreatedBy = a.CreatedByAppUser.FirstName + " " + a.CreatedByAppUser.LastName,
            }); ;
            dataDTO = QueryHelper.Ordering(dataDTO, filter.SortColumn, filter.SortDirection != "asc", false);

            return dataDTO.ToPagedList(filter.Page, filter.PageSize);
        }
        private IQueryable<Student> GetData(StudentFilter filter)
        {
            var data = GetAll.Where(a => a.IsActive);

            //Filter
            if (!string.IsNullOrWhiteSpace(filter.LastName))
            {
                filter.LastName = filter.LastName.Trim();
                data = data.Where(a => a.LastName.Contains(filter.LastName));
            }
            if (!string.IsNullOrWhiteSpace(filter.FirstName))
            {
                filter.FirstName = filter.FirstName.Trim();
                data = data.Where(a => a.FirstName.Contains(filter.FirstName));
            }
            if (!string.IsNullOrWhiteSpace(filter.MiddleName))
            {
                filter.MiddleName = filter.MiddleName.Trim();
                data = data.Where(a => a.MiddleName.Contains(filter.MiddleName));
            }
            if (!string.IsNullOrWhiteSpace(filter.StudentNo))
            {
                filter.StudentNo = filter.StudentNo.Trim();
                data = data.Where(a => a.StudentNo.Contains(filter.StudentNo));
            }
            if (!string.IsNullOrWhiteSpace(filter.Address))
            {
                filter.Address = filter.Address.Trim();
                data = data.Where(a => a.Address.Contains(filter.Address));
            }
            if (filter.GenderId != null)
            {
                data = data.Where(a => a.GenderId == filter.GenderId);
            }
            //if (filter.ReligionId != null)
            //{
            //    data = data.Where(a => a.ReligionId == filter.ReligionId);
            //}
            //if (!string.IsNullOrWhiteSpace(filter.CreatedBy))
            //{
            //    filter.CreatedBy = filter.CreatedBy.Trim();
            //    data = data.Where(a => (a.CreatedByAppUser.FirstName + " "
            //    + a.CreatedByAppUser.LastName)
            //    .Trim().Contains(filter.CreatedBy));
            //}
            return data;
        }
    }
}
