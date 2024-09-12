using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDto;
using TazeCase.Form.Core.Wrappers.Response;

namespace TazeCase.Form.Business.Service.Form
{
    public interface IFormService
    {
        Task<BaseResponse<List<FormOutputDto>>> GetAllAsync();
        Task<BaseResponse<List<FormOutputDto>>> GetFilteredAsync(int? limit = null, int? pageNumber = null, int? pageSize = null);
        Task<BaseResponse<FormOutputDto>> AddAsync(FormInputDto entityDto);
        Task<BaseResponse<FormOutputDto>> GetByIdAsync(Guid id);
        Task<BaseResponse<FormOutputDto>> Update(Guid id, FormInputDto entityDto);
        Task<BaseResponse<bool>> Delete(Guid id);
        Task<BaseResponse<bool>> UpdateActiveStatus(FormInputActiveStatusDto isActiveDto);
    }
}
