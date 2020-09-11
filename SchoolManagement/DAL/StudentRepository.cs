using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using SchoolManagement.DTO;
using SchoolManagement.DAL;
using SchoolManagement.Interface.Repository;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.DAL
{
    public class StudentRepository : Repository<SinhVien,DB>,IStudentRepository
    {
        DB _db;
     public StudentRepository(DB db) : base(db)
        {
            _db = db;
        }

        public Task<List<SinhVien>> GetAll(Filter filter)
        {
           return _db.SinhViens.Where(x =>
             string.IsNullOrEmpty(filter.FullName) || x.FullName == filter.FullName).ToListAsync();
        }
    }
}
