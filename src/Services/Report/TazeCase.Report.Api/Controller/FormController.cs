using Microsoft.AspNetCore.Mvc;
using TazeCase.Report.Business.Services.FormService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TazeCase.Report.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService formService;

        public FormController(IFormService formService)
        {
            this.formService = formService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var res = await formService.GetFormReportAsync();
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }


    }
}
