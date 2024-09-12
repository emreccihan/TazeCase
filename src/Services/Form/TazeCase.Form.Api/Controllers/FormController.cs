using Azure;
using Microsoft.AspNetCore.Mvc;
using TazeCase.Form.Business.DTOs.FormDto;
using TazeCase.Form.Business.Service.Form;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TazeCase.Form.Api.Controllers
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await formService.GetAllAsync();
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }
        [HttpGet]
        [Route("Filtered")]
        public async Task<IActionResult> GetFiltered([FromQuery] int? limit = null, [FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null)
        {
            var res = await formService.GetFilteredAsync(limit, pageNumber, pageSize);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await formService.GetByIdAsync(id);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormInputDto entityDto)
        {
            var res = await formService.AddAsync(entityDto);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }

        // PUT api/<FormController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] FormInputDto entityDto)
        {
            var res = await formService.Update(id,entityDto);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }

        // DELETE api/<FormController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await formService.Delete(id);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }
        [HttpPost()]
        [Route("IsActive")]

        public async Task<IActionResult> UpdateActiveStatus([FromBody] FormInputActiveStatusDto entityDto)
        {
            var res = await formService.UpdateActiveStatus(entityDto);
            if (res.Status != 200)
                return StatusCode(res.Status, res);

            return Ok(res);
        }
    }
}
