using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Core.Entities;
using TazeCase.Form.Core.Repository;
using TazeCase.Form.Data.Context;

namespace TazeCase.Form.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly FormDataContext context;
        public GenericRepository(FormDataContext context)
        {
            this.context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity= await context.Set<T>().FirstOrDefaultAsync(q => q.Id == id);
            if (entity == null)
                return false;
            entity.IsDeleted= true;
            var result =await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<List<T>> GetAllAsyncInc(Expression<Func<T, object>>[] includeProperties = null)
        {
            var query = context.Set<T>().AsQueryable();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.ToListAsync();

            //return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(q=>q.Id==id);
        }

        public async Task<List<T>> GetFilteredAsync(int? limit = null, int? pageNumber = null, int? pageSize = null)
        {
            var query = context.Set<T>().AsQueryable();

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            else if (limit.HasValue) 
            {
                query = query.Take(limit.Value);
            }

            return await query.ToListAsync();
        }
        public async Task<List<T>> GetFilteredIncAsync(Expression<Func<T, object>>[] includeProperties = null,int ? limit = null, int? pageNumber = null, int? pageSize = null)
        {
            var query = context.Set<T>().AsQueryable();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            else if (limit.HasValue)
            {
                query = query.Take(limit.Value);
            }

            return await query.ToListAsync();
        }
        public async Task<T> Update(T entity)
        {
            var existingEntity = await context.Set<T>().FindAsync(entity.Id);
            if (existingEntity == null)
                return null;

            context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();
            return existingEntity;
        }
    }
}
