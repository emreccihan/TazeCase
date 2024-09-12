using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Core.Entities;

namespace TazeCase.Form.Core.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsyncInc(Expression<Func<T, object>>[] includeProperties = null);
        Task<List<T>> GetFilteredAsync(int? limit = null, int? pageNumber = null, int? pageSize = null);
        Task<List<T>> GetFilteredIncAsync(Expression<Func<T, object>>[] includeProperties = null, int? limit = null, int? pageNumber = null, int? pageSize = null);
        Task<T> GetByIdAsync(Guid id);

        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
