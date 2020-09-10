using SchoolManagement.DTO;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public interface IStudentRepository
    {
       // Task<List<StudentViewModel>> GetStudents();

        Task<StudentViewModel> GetStudent(int? studentId);

        Task<int> AddStudent(SinhVien sinhVien);

        Task<int> DeleteStudent(int? studentId);

        Task UpdateStudent(SinhVien sinhVien);
    }
}
