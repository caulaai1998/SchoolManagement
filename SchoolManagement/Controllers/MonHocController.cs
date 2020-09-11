using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DAL;
using SchoolManagement.DTO;
using SchoolManagement.Interface.Repository;
using SchoolManagement.Interface.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : MyMDBController<MonHoc, IMonHocRepository>
    {
        IMonHocRepository _repository;
        public MonHocController(IMonHocRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }
        public Task<List<MonHoc>> Find([FromQuery]Filter filter)
        {
            return _repository.GetAll(filter);
        }
    }
}
