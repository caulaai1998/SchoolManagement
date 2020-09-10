using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using SchoolManagement.Repository;
using SchoolManagement.Repository.Entity;
using StackExchange.Redis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyMDBController<T,TRepositoy> : ControllerBase
        where T: class,IEntity
        where TRepositoy:IRepository<T>
    {
        private readonly TRepositoy repositoy;
        public MyMDBController(TRepositoy repositoy)
        {
            this.repositoy = repositoy;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return await repositoy.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(int id)
        {
            var student = await repositoy.Get(id);
            if (student == null) return NotFound();
            return student;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Put(int id,T student)
        {
            if (id != student.ID) return BadRequest();
            await repositoy.Update(student);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<T>> Post(T student)
        {
            await repositoy.Add(student);
            return CreatedAtAction("Get", new { id = student.ID }, student);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<T>> Delete(int id)
        {
            var student = await repositoy.Delete(id);
            if (student == null) return NotFound();

            return student;
        }
    }
}
