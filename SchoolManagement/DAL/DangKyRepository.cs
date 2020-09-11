using Microsoft.EntityFrameworkCore;
using SchoolManagement.DTO;
using SchoolManagement.Interface.Repository;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.DAL
{
    public class DangKyRepository : Repository<DangKiMonHoc,DB>,IDangKyRepository
    {
        DB _db;
        public DangKyRepository(DB db) : base(db)
        {
            _db = db;
        }

        public Task<List<DangKiMonHoc>> GetAll(Filter filter)
        {
            return _db.DangKiMonHocs.Where(x =>
          (filter.StudentID == 0 || x.SinhVienID == filter.StudentID)
          && (filter.SubjectID == 0 || x.MonHocID == filter.SubjectID)
          ).ToListAsync();
        }
    }
}
