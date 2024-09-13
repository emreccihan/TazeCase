using Microsoft.AspNetCore.Mvc;
using TazeCase.Form.Business.DTOs.FormDataDto;
using TazeCase.Form.Business.DTOs.FormFieldDto;
using TazeCase.Form.Business.Service.FormData;
using TazeCase.Form.Business.Service.FormField;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TazeCase.Form.Api.Controllers
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await formDataService.GetAllAsync();
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await formDataService.GetByIdAsync(id);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }

        [HttpGet()]
        [Route("ByFormId/{formId}")]
        public async Task<IActionResult> GetByFormId(Guid formId)
        {
            var res = await formDataService.GetFormDataByFormId(formId);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormDataInputDto entityDto)
        {
            var res = await formDataService.AddAsync(entityDto);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }
        [HttpPost]
        [Route("AddListData")]

        public async Task<IActionResult> PostList([FromBody] List<FormDataInputDto> entityDto)
        {
            var res = await formDataService.AddListFormData(entityDto);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] FormDataInputDto entityDto)
        {
            var res = await formDataService.Update(id, entityDto);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await formDataService.Delete(id);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }
    }
}
