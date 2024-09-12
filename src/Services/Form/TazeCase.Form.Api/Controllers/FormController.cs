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
                return StatusCode(res.Status, res.Message);

            return Ok(res);
        }

        // GET api/<FormController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FormController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormInputDto entityDto)
        {
            var res = await formService.AddAsync(entityDto);
            if (res.Status != 200)
                return StatusCode(res.Status, res.Message);

            return Ok(res);
        }

        // PUT api/<FormController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FormController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
