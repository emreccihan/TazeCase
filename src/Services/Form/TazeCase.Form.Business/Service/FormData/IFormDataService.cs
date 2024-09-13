using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDataDto;
using TazeCase.Form.Business.DTOs.FormDto;
using TazeCase.Form.Business.DTOs.FormFieldDto;
using TazeCase.Form.Core.Entities;
using TazeCase.Form.Core.Service;
using TazeCase.Form.Core.Wrappers.Response;

namespace TazeCase.Form.Business.Service.FormData
{
    public interface IFormDataService: IGenericService<Core.Entities.FormDataValue, FormDataInputDto, FormDataOutputDto>
    {
        Task<BaseResponse<List<FormDataGroupByFrom>>> GetFormDataByFormId(Guid formId);
        Task<BaseResponse<List<FormDataOutputDto>>> AddListFormData(List<FormDataInputDto> entitiesDto);

    }
}
