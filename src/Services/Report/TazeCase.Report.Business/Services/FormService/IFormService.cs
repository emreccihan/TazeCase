using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Report.Core.DTOs.FormDto;
using TazeCase.Report.Core.Wrappers.Response;

namespace TazeCase.Report.Business.Services.FormService
{
    public interface IFormService
    {
        Task<BaseResponse<List<FormOutputDto>>> GetFormReportAsync(Guid FormId);
    }
}
