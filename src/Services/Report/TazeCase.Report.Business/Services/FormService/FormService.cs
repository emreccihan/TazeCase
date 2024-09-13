using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Report.Core.DTOs.FormDto;
using TazeCase.Report.Core.Wrappers.Response;

namespace TazeCase.Report.Business.Services.FormService
{
    public class FormService : IFormService
    {
        private readonly HttpClient _httpClient;

        public FormService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<BaseResponse<List<FormOutputDto>>> GetFormReportAsync(Guid FormId)
        {
            try
            {
                var response = await _httpClient.GetAsync("http://localhost:5000/api/form");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var forms = JsonConvert.DeserializeObject<List<FormOutputDto>>(content);
                return BaseResponse<List<FormOutputDto>>.Success(forms, "Form updated successfully");
            }
            catch (Exception ex)
            {

                return BaseResponse<List<FormOutputDto>>.Error("An error occurred while updated form: " + ex.Message);
            }
        }
    }
}
