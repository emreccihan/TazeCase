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
        Task<BaseResponse<FormOutputDto>> AddAsync(FormInputDto entityDto);
    }
}
