using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using SchoolManagement.DTO;
using SchoolManagement.Interface.Repository;
using SchoolManagement.Interface.UnitOfWork;
using SchoolManagement.Repository;
using SchoolManagement.Repository.Entity;
using StackExchange.Redis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolManagement.Controllers
{   
    [ApiController]
    public class MyMDBController<T,TRepositoy> : ControllerBase
        where T: class,IEntity
        where TRepositoy:IRepository<T>
    {
        private readonly TRepositoy repository;
        private readonly IUnitOfWork unitOfWork;
        public MyMDBController(TRepositoy repository,IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(int id)
        {
            var student = await repository.Get(id);
            if (student == null) return NotFound();
            return student;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Put(int id,T student)
        {
            if (id != student.ID) return BadRequest();
            await repository.Update(student);
            unitOfWork.Commit();
            return NoContent();
            
        }

        [HttpPost]
        public async Task<ActionResult<T>> Post(T student)
        {
            await repository.Add(student);
            unitOfWork.Commit();
            return CreatedAtAction("Get", new { id = student.ID }, student);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<T>> Delete(int id)
        {
            var student = await repository.Delete(id);
            if (student == null) return NotFound();
            unitOfWork.Commit();
            return student;
        }
    }
}
