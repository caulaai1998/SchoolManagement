using SchoolManagement.DTO;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Interface.Repository
{
    public interface IDangKyRepository: IRepository<DangKiMonHoc>
    {
        Task<List<DangKiMonHoc>> GetAll(Filter filter);
    }
}
