using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Core.Entities;

namespace TazeCase.Form.Core.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
        Task<T> DeleteAsync(Guid id);
    }
}
