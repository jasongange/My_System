using App.Models.DTO.Student;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Service.Student
{
   public interface IStudentService
    {
        IPagedList<SearchStudentDTO> SearchStudent(StudentFilter filter);
        Domain.Models.Student GetById(int id);
        void InsertOrUpdate(Domain.Models.Student student, int appUserId);
        StudentDetailsDTO GetDetails(int studentId);
    }
}
