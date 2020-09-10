using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using SchoolManagement.DTO;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public class StudentRepository : IStudentRepository
    {
        DB db;
        public StudentRepository(DB _db)
        {
            db = _db;
        }

        public async Task<int> AddStudent(SinhVien sinhVien)
        {
            if(db != null)
            {
                await db.SinhViens.AddAsync(sinhVien);
                await db.SaveChangesAsync();

                return sinhVien.ID;
            }
            return 0;
        }

        public async Task<int> DeleteStudent(int? studentId)
        {
            int result = 0;
            if(db !=null)
            {
                var student = await db.SinhViens.FirstOrDefaultAsync(x => x.ID == studentId);
                
                if(student != null)
                {
                    // Delete student
                    db.SinhViens.Remove(student);
                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<StudentViewModel> GetStudent(int? studentId)
        {
            if(db != null)
            {
                return await (from s in db.SinhViens
                             
                              where s.ID == studentId
                              select new StudentViewModel
                              {
                                  ID = s.ID,
                                  FullName = s.FullName,
                                  CreateAt = s.CreateAt,
                                  UpdateAt = s.UpdateAt
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        //public async Task<List<StudentViewModel>> GetStudents()
        //{
        //    if (db != null)
        //    {
        //        return await (from s in db.SinhViens

        //                      where s.ID == studentId
        //                      select new StudentViewModel
        //                      {
        //                          ID = s.ID,
        //                          FullName = s.FullName,
        //                          CreateAt = s.CreateAt,
        //                          UpdateAt = s.UpdateAt
        //                      }).FirstOrDefaultAsync();
        //    }
        //    return null;
        //}

        public async Task UpdateStudent(SinhVien sinhVien)
        {
            if(db !=null)
            {
                // delete that student
                db.SinhViens.Update(sinhVien);
                //commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
