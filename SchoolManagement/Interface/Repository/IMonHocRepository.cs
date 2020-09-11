using SchoolManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Interface.Repository
{
    public interface IMonHocRepository:IRepository<MonHoc>
    {
        Task<List<MonHoc>> GetAll(Filter filter);
    }
}
