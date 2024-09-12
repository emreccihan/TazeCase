using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDto;
using TazeCase.Form.Business.DTOs.FormFieldDto;
using TazeCase.Form.Core.Service;
using TazeCase.Form.Core.Wrappers.Response;

namespace TazeCase.Form.Business.Service.FormField
{
    public interface IFormFieldService: IGenericService<Core.Entities.FormField, FormFieldInputDto, FormFieldOutputDto>
    {
        Task<BaseResponse<List<FormFieldOutputDto>>> GetAllIncludeAsync();
        Task<BaseResponse<List<FormFieldOutputDto>>> GetFilteredIncludeAsync(int? limit = null, int? pageNumber = null, int? pageSize = null);

    }
}
