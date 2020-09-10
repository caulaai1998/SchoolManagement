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
    public class StudentController : ControllerBase
    {
        IStudentRepository studentRepository;
        public StudentController(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }
        [HttpGet]
        [Route("GetStudent")]
        public async Task<IActionResult> GetStudent(int? studentId)
        {
            if(studentId == null)
            {
                return BadRequest();
            }
            try
            {
                var student = await studentRepository.GetStudent(studentId);

                if(student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody]SinhVien model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var studentId = await studentRepository.AddStudent(model);
                    if(studentId < 0)
                    {
                        return Ok(studentId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch(Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(int? studentId)
        {
            int result = 0;
            if(studentId == null)
            {
                return BadRequest();
            }
            try
            {
                result = await studentRepository.DeleteStudent(studentId);  
                if (result == 0) return NotFound();
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody]SinhVien model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    await studentRepository.UpdateStudent(model);
                    return Ok();
                }
                catch(Exception ex)
                {
                    if(ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
