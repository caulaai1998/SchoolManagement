using Microsoft.EntityFrameworkCore;
using SchoolManagement.DTO;
using SchoolManagement.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.DAL
{
    public class MonHocRepository:Repository<MonHoc,DB>,IMonHocRepository
    {
        DB _db;
        public MonHocRepository(DB db) : base(db)
        {
            _db = db;
        }

        public Task<List<MonHoc>> GetAll(Filter filter)
        {
            return _db.MonHocs.Where(x =>
          string.IsNullOrEmpty(filter.Subject) || x.Subject == filter.Subject).ToListAsync();
        }
    }
}
