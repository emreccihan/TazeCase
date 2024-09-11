using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Core.Entities;
using TazeCase.Form.Core.Repository;
using TazeCase.Form.Data.Context;

namespace TazeCase.Form.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly FormDataContext context;
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

        public async Task<T> DeleteAsync(Guid id)
        {
            var entity= await context.Set<T>().FirstOrDefaultAsync(q => q.Id == id);
            if (entity == null)
                return null;
            entity.IsDeleted= true;
            await context.SaveChangesAsync();

            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(q=>q.Id==id);
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
