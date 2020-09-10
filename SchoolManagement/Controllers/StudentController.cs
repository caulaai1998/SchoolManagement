using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators;
using SchoolManagement.DTO;
using SchoolManagement.Repository;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : MyMDBController<SinhVien,StudentRepository>
    {
        public StudentController(StudentRepository repository):base(repository)
        {
        }
    }
}
