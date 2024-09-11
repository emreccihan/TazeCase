using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDto;
using TazeCase.Form.Core.Repository;
using TazeCase.Form.Core.Wrappers.Response;
using TazeCase.Form.Data.Repository;

namespace TazeCase.Form.Business.Service.Form
{
    public class FormService : IFormService
    {
        private readonly IFormRepository formRepository;
        private readonly IMapper mapper;

        public FormService(IFormRepository formRepository,IMapper mapper)
        {
            this.formRepository = formRepository;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<List<FormOutputDto>>> GetAllAsync()
        {
            try
            {
                var res = await formRepository.GetAllAsync();
                var resDto = this.mapper.Map<List<FormOutputDto>>(res);
                return BaseResponse<List<FormOutputDto>>.Success(resDto, "Forms fetched successfully");
            }
            catch (Exception ex)
            {

                return BaseResponse<List<FormOutputDto>>.Error("An error occurred while fetching forms: " + ex.Message);
            }

        }
    }
}
