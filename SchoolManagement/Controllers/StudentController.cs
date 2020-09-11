﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators;
using SchoolManagement.DAL;
using SchoolManagement.DTO;
using SchoolManagement.Interface.Repository;
using SchoolManagement.Interface.UnitOfWork;
using SchoolManagement.Repository;
using SchoolManagement.ViewModel;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : MyMDBController<SinhVien,IStudentRepository>
    {
        IStudentRepository _repository;
        public StudentController(IStudentRepository repository,IUnitOfWork unitOfWork):base(repository,unitOfWork)
        {
            _repository = repository;
        }

     
        [HttpGet]
        public Task<List<SinhVien>> Find([FromQuery]Filter filter)
        {
            return _repository.GetAll(filter);
        }
    }
}
