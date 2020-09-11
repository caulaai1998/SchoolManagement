using SchoolManagement.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Interface.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
    }
}
