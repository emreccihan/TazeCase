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
        private readonly IFormFieldRepository formFieldRepository;
        private readonly IMapper mapper;

        public FormDataService(IFormDataRepository formDataRepository, IMapper mapper, IFormFieldRepository formFieldRepository)
            : base(formDataRepository, mapper) 
        {
            this.formDataRepository = formDataRepository;
            this.mapper = mapper;
            this.formFieldRepository = formFieldRepository;
        }

        public async Task<BaseResponse<List<FormDataOutputDto>>> AddListFormData(List<FormDataInputDto> entitiesDto)
        {
            try
            {
                var formFields =await formFieldRepository.GetFormFieldsByFormId(entitiesDto.FirstOrDefault().FormId);
                var requiredFields = formFields
                    .Where(ff => ff.IsRequired && entitiesDto.Any(e => e.FormFieldId == ff.Id && string.IsNullOrEmpty(e.Value)|| !entitiesDto.Any(e => e.FormFieldId == ff.Id)))
                    .ToList();

                if (requiredFields.Any())
                {
                    var missingFields = string.Join(", ", requiredFields.Select(f => f.FieldName));
                    return BaseResponse<List<FormDataOutputDto>>.Error($"The following required fields are missing or empty: {missingFields}");
                }
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


                var resGroupBaya = res
                    .GroupBy(x => x.FormId)
                    .Select(group => new FormDataGroupByFrom
                    {
                        FormId = group.Key,

                        Form = group.FirstOrDefault()?.Form != null
                            ? mapper.Map<FormOutputDto>(group.First().Form)
                            : null,
                        FormData = group
                            .GroupBy(x => x.FormFieldId)
                            .Select(fieldGroup => new FormFieldDataGroupedDto
                            {
                                FormFieldId = fieldGroup.Key,
                                FormField = mapper.Map<FormFieldBaseOutputDto>(fieldGroup.First().FormField),
                                Data = fieldGroup.Select(item => new FormDataValueDto
                                {
                                    Value = item.Value,
                                    Id = item.Id,
                                    IsDeleted = item.IsDeleted
                                }).ToList()
                            }).ToList()
                    })
                    .ToList();
                return BaseResponse<List<FormDataGroupByFrom>>.Success(resGroupBaya, "Entities fetched successfully");


            }
            catch (Exception ex)
            {

                return BaseResponse<List<FormDataGroupByFrom>>.Error("An error occurred while fetching entities: " + ex.Message);
            }
        }
    }
}
