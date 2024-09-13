using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Report.Core.DTOs.FormDataDto;
using TazeCase.Report.Core.Wrappers.Input;
using TazeCase.Report.Core.Wrappers.Response;

namespace TazeCase.Report.Business.Services.FormDataService
{
    public class FormDataService : IFormDataService
    {
        private readonly HttpClient _httpClient;

        public FormDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<BaseResponse<List<FormDataOutputDto>>> GetFormDataReportAsync(Guid formId)
        {
            try
            {
                var requestUrl = $"https://localhost:5000/api/FormData/ByFormId/{formId}";

                var response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var forms = JsonConvert.DeserializeObject<BaseJson<List<FormDataOutputDto>>>(content);
                return BaseResponse<List<FormDataOutputDto>>.Success(forms.Body, "Form report fetched successfully");
            }
            catch (Exception ex)
            {

                return BaseResponse<List<FormDataOutputDto>>.Error("An error occurred while updated form: " + ex.Message);
            }
        }
    }
}
