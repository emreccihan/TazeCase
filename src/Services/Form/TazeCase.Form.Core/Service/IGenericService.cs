using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Core.Entities;
using TazeCase.Form.Core.Wrappers.Response;

namespace TazeCase.Form.Core.Service
{
    public interface IGenericService<TEntity, TInputDto, TOutputDto>
        where TEntity : BaseEntity
    {
        Task<BaseResponse<List<TOutputDto>>> GetAllAsync();
        Task<BaseResponse<List<TOutputDto>>> GetFilteredAsync(int? limit = null, int? pageNumber = null, int? pageSize = null);
        Task<BaseResponse<TOutputDto>> AddAsync(TInputDto entityDto);
        Task<BaseResponse<TOutputDto>> GetByIdAsync(Guid id);
        Task<BaseResponse<TOutputDto>> Update(Guid id, TInputDto entityDto);
        Task<BaseResponse<bool>> Delete(Guid id);
    }
}
