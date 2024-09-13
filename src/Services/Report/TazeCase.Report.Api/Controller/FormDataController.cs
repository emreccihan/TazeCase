using Microsoft.AspNetCore.Mvc;
using TazeCase.Report.Business.Services.FormDataService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TazeCase.Report.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormDataController : ControllerBase
    {
        private readonly IFormDataService formDataService;

        public FormDataController(IFormDataService formDataService)
        {
            this.formDataService = formDataService;
        }

        [HttpGet("{formId}")]
        public async Task<IActionResult> Get(Guid formId)
        {
            var res = await formDataService.GetFormDataReportAsync(formId);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }


    }
}
