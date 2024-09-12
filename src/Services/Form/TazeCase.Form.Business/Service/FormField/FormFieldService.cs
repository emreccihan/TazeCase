using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDto;
using TazeCase.Form.Business.DTOs.FormFieldDto;
using TazeCase.Form.Core.Repository;
using TazeCase.Form.Core.Wrappers.Response;

namespace TazeCase.Form.Business.Service.FormField
{
    public class FormFieldService : GenericService<Core.Entities.FormField, FormFieldInputDto, FormFieldOutputDto>, IFormFieldService
    {
        private readonly IFormFieldRepository formFieldRepository;
        private readonly IMapper mapper;

        //public FormService(IFormRepository formRepository,IMapper mapper)
        //{
        //    this.formRepository = formRepository;
        //    this.mapper = mapper;
        //}
        public FormFieldService(IFormFieldRepository formFieldRepository, IMapper mapper)
            : base(formFieldRepository, mapper)
        {
            this.formFieldRepository = formFieldRepository;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<List<FormFieldOutputDto>>> GetAllIncludeAsync()
        {
            try
            {

                var res = await formFieldRepository.GetAllAsyncInc(new Expression<Func<Core.Entities.FormField, object>>[] { q => q.Form });
                var resDto = this.mapper.Map<List<FormFieldOutputDto>>(res);
                return BaseResponse<List<FormFieldOutputDto>>.Success(resDto, "Entities fetched successfully");
            }
            catch (Exception ex)
            {
                return BaseResponse<List<FormFieldOutputDto>>.Error("An error occurred while fetching entities: " + ex.Message);
            }
        }

        public async Task<BaseResponse<List<FormFieldOutputDto>>> GetFilteredIncludeAsync(int? limit = null, int? pageNumber = null, int? pageSize = null)
        {
            try
            {

                var res = await formFieldRepository.GetFilteredIncAsync(new Expression<Func<Core.Entities.FormField, object>>[] { q => q.Form },limit,pageNumber,pageSize);
                var resDto = this.mapper.Map<List<FormFieldOutputDto>>(res);
                return BaseResponse<List<FormFieldOutputDto>>.Success(resDto, "Entities fetched successfully");
            }
            catch (Exception ex)
            {
                return BaseResponse<List<FormFieldOutputDto>>.Error("An error occurred while fetching entities: " + ex.Message);
            }
        }

        public async Task<BaseResponse<List<FormFieldGroupByFormDto>>> GetFormFieldByFormId(Guid formId)
        {
            try
            {
                var res =await formFieldRepository.GetFormFieldsByFormId(formId);
                //var resGroupBy=res.GroupBy(x => x.FormId).Select(group=>new FormFieldGroupByFormDto
                //{
                //    FormId=group.Key,
                //    Form = group.FirstOrDefault()?.Form != null
                //    ? mapper.Map<FormOutputDto>(group.First().Form)
                //    : null,
                //    FormFields =mapper.Map<List<FormFieldBaseOutputDto>>(group)
                //}).ToList();
                var resGroupBy = mapper.Map<List<FormFieldGroupByFormDto>>(res.GroupBy(x => x.FormId).ToList());

                return BaseResponse<List<FormFieldGroupByFormDto>>.Success(resGroupBy, "Entities fetched successfully");

            }
            catch (Exception ex)
            {

                return BaseResponse<List<FormFieldGroupByFormDto>>.Error("An error occurred while fetching entities: " + ex.Message);
            }
        }

        //public Task<BaseResponse<List<FormFieldOutputDto>>> GetAllIncludeAsync(System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties = null)
        //{
        //    var query = context.Set<T>().AsQueryable();
        //    if (includeProperties != null)
        //    {
        //        foreach (var includeProperty in includeProperties)
        //        {
        //            query = query.Include(includeProperty);
        //        }
        //    }
        //    return await query.ToListAsync();

        //    //return await context.Set<T>().ToListAsync();        }
        //}
    }
}