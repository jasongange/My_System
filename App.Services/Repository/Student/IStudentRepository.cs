using App.Domain.Models;
using App.Models.DTO.Student;
using Codebiz.Domain.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repository
{
   public interface IStudentRepository : IRepositoryBase<Student>
    {
        IPagedList<SearchStudentDTO> SearchStudent(StudentFilter filter);
        Student GetById(int id);
        void InsertOrUpdate(Student student, int appUserId);
        StudentDetailsDTO GetDetails(int navlinkId);
    }
}
