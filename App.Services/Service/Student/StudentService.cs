using App.Models.DTO.Student;
using Infrastructures.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Service.Student
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(
        IStudentRepository studentRepository
        )
        {
            _studentRepository = studentRepository;
        }

        public Domain.Models.Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public StudentDetailsDTO GetDetails(int studentId)
        {
            return _studentRepository.GetDetails(studentId);
        }

        public void InsertOrUpdate(Domain.Models.Student entity, int id)
        {
            if (entity.StudentId.Equals(0))
            {
                var now = DateTime.Now;

                entity.CreatedByAppUserId = id;
                entity.CreatedOn = now;
                entity.IsActive = true;
            }
            else
            {
                entity.ModifiedByAppUserId = id;
                entity.ModifiedOn = DateTime.Now;
            }
            _studentRepository.InsertOrUpdate(entity);
        }

        public IPagedList<SearchStudentDTO> SearchStudent(StudentFilter filter)
        {
            return _studentRepository.SearchStudent(filter);
        }
    }
}
