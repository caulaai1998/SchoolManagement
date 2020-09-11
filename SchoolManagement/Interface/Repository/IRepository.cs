using SchoolManagement.DTO;
using SchoolManagement.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Interface.Repository
{
    public interface IRepository<T> where T: class, IEntity
    {
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
