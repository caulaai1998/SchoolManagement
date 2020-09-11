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
    public class DangKyController : MyMDBController<DangKiMonHoc, IDangKyRepository>
    {
        IDangKyRepository _repository;
        public DangKyController(IDangKyRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        [HttpGet]
        public Task<List<DangKiMonHoc>> Find([FromQuery]Filter filter)
        {
            return _repository.GetAll(filter);
        }
    }
}
