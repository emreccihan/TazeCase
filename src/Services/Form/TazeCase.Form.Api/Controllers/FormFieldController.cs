using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using TazeCase.Form.Business.DTOs.FormDto;
using TazeCase.Form.Business.DTOs.FormFieldDto;
using TazeCase.Form.Business.Service.Form;
using TazeCase.Form.Business.Service.FormField;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TazeCase.Form.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormFieldController : ControllerBase
    {
        private readonly IFormFieldService formFieldService;

        public FormFieldController(IFormFieldService formFieldService)
        {
            this.formFieldService = formFieldService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await formFieldService.GetAllIncludeAsync();
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }
        [HttpGet()]
        [Route("ByFormId/{formId}")]

        public async Task<IActionResult> GetByFromId(Guid formId)
        {
            var res = await formFieldService.GetFormFieldByFormId(formId);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }
        [HttpGet]
        [Route("Filtered")]
        public async Task<IActionResult> GetFiltered([FromQuery] int? limit = null, [FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null)
        {
            var res = await formFieldService.GetFilteredIncludeAsync(limit, pageNumber, pageSize);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await formFieldService.GetByIdAsync(id);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormFieldInputDto entityDto)
        {
            var res = await formFieldService.AddAsync(entityDto);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }

        // PUT api/<FormFieldController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] FormFieldInputDto entityDto)
        {
            var res = await formFieldService.Update(id, entityDto);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await formFieldService.Delete(id);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }
    }
}
