using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Report.Core.DTOs.FormDataDto;
using TazeCase.Report.Core.Wrappers.Response;

namespace TazeCase.Report.Business.Services.FormDataService
{
    public interface IFormDataService
    {
        Task<BaseResponse<List<FormDataOutputDto>>> GetFormDataReportAsync(Guid formId);

    }
}
