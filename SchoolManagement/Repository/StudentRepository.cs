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
    public class StudentRepository : Repository<SinhVien,DB>
    {
     public StudentRepository(DB db) : base(db)
        {
        }
    }
}
