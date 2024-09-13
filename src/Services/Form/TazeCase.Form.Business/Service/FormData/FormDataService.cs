using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDataDto;
using TazeCase.Form.Business.DTOs.FormDto;
using TazeCase.Form.Business.DTOs.FormFieldDto;
using TazeCase.Form.Business.Service.Form;
using TazeCase.Form.Core.Entities;
using TazeCase.Form.Core.Repository;
using TazeCase.Form.Core.Wrappers.Response;
using TazeCase.Form.Data.Repository;

namespace TazeCase.Form.Business.Service.FormData
{
    public class FormDataService: GenericService<Core.Entities.FormDataValue, FormDataInputDto, FormDataOutputDto>,IFormDataService
    {
        private readonly IFormDataRepository formDataRepository;
        private readonly IMapper mapper;

        public FormDataService(IFormDataRepository formDataRepository, IMapper mapper)
            : base(formDataRepository, mapper) 
        {
            this.formDataRepository = formDataRepository;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<List<FormDataOutputDto>>> AddListFormData(List<FormDataInputDto> entitiesDto)
        {
            try
            {

                var entities = mapper.Map<List<FormDataValue>>(entitiesDto);
                var res=await formDataRepository.AddListFormData(entities);
                var resDto=mapper.Map<List<FormDataOutputDto>>(res);
                return BaseResponse<List<FormDataOutputDto>>.Success(resDto, "Entities fetched successfully");

            }
            catch (Exception ex)
            {

                return BaseResponse<List<FormDataOutputDto>>.Error("An error occurred while fetching entities: " + ex.Message);
            }

        }

        public async Task<BaseResponse<List<FormDataGroupByFrom>>> GetFormDataByFormId(Guid formId)
        {
            try
            {
                var res = await formDataRepository.GetFormDatasByFormId(formId);

                var resGroupBy = mapper.Map<List<FormDataGroupByFrom>>(res.GroupBy(x => x.FormId).ToList());

                return BaseResponse<List<FormDataGroupByFrom>>.Success(resGroupBy, "Entities fetched successfully");

            }
            catch (Exception ex)
            {

                return BaseResponse<List<FormDataGroupByFrom>>.Error("An error occurred while fetching entities: " + ex.Message);
            }
        }
    }
}
