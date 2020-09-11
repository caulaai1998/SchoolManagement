using SchoolManagement.DTO;
using SchoolManagement.Interface.Repository;
using SchoolManagement.Interface.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DB _db;
      
        public UnitOfWork(DB db)
        {
          _db=db;
        }
        public void Commit()
        {
            _db.SaveChanges();
        }

        public void RollBack()
        {
            _db.Dispose();
        }
    }
}
