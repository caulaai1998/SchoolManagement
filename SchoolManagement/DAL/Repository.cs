using Microsoft.EntityFrameworkCore;
using SchoolManagement.DTO;
using SchoolManagement.Interface.Repository;
using SchoolManagement.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.DAL
{
    public class Repository<T, TContext> : IRepository<T>
        where T : class,IEntity
        where TContext : DB
    {
        private readonly TContext context;

        public Repository(TContext context)
        {
            this.context = context;
        }

        public async Task<T> Add(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null) return entity;

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Get(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }


        public async Task<T> Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
