using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDto;
using TazeCase.Form.Core.Entities;
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

        public async Task<BaseResponse<FormOutputDto>> AddAsync(FormInputDto entityDto)
        {
            try
            {
                var entity=this.mapper.Map<Core.Entities.Form>(entityDto);
                var res = await formRepository.AddAsync(entity);
                var resDto = this.mapper.Map<FormOutputDto>(res);
                return BaseResponse<FormOutputDto>.Success(resDto, "Form added successfully");

            }
            catch (Exception ex)
            {

                return BaseResponse<FormOutputDto>.Error("An error occurred while added form: " + ex.Message);
            }
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
        public async Task<BaseResponse<FormOutputDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var res = await formRepository.GetByIdAsync(id);
                var resDto = this.mapper.Map<FormOutputDto>(res);
                return BaseResponse<FormOutputDto>.Success(resDto, "Forms fetched successfully");
            }
            catch (Exception ex)
            {

                return BaseResponse<FormOutputDto>.Error("An error occurred while fetching forms: " + ex.Message);
            }

        }
        public async Task<BaseResponse<List<FormOutputDto>>> GetFilteredAsync(int? limit = null, int? pageNumber = null, int? pageSize = null)
        {
            try
            {
                var res = await formRepository.GetFilteredAsync(limit, pageNumber, pageSize);
                var resDto = this.mapper.Map<List<FormOutputDto>>(res);
                return BaseResponse<List<FormOutputDto>>.Success(resDto, "Forms fetched successfully");
            }
            catch (Exception ex)
            {
                return BaseResponse<List<FormOutputDto>>.Error("An error occurred while fetching forms: " + ex.Message);
            }
        }

        public async Task<BaseResponse<FormOutputDto>> Update(Guid id, FormInputDto entityDto)
        {
            try
            {
                var entity = this.mapper.Map<Core.Entities.Form>(entityDto);
                entity.Id = id;
                var res = await formRepository.Update(entity);
                var resDto = this.mapper.Map<FormOutputDto>(res);
                return BaseResponse<FormOutputDto>.Success(resDto, "Form updated successfully");
            }
            catch (Exception ex)
            {
                return BaseResponse<FormOutputDto>.Error("An error occurred while updated form: " + ex.Message);
            }
        }

        public async Task<BaseResponse<bool>> Delete(Guid id)
        {
            try
            {
                var res = await formRepository.DeleteAsync(id);
                if(res)
                    return BaseResponse<bool>.Success(true, "Form deleted successfully");
                else
                    return BaseResponse<bool>.Success(false , "No Data Found");

            }
            catch (Exception ex)
            {
                return BaseResponse<bool>.Error("An error occurred while updated form: " + ex.Message);
            }
        }
        public async Task<BaseResponse<bool>> UpdateActiveStatus(FormInputActiveStatusDto isActiveDto)
        {
            try
            {
                var entity = this.mapper.Map<Core.Entities.Form>(isActiveDto);
                var res = await formRepository.UpdateActiveStatus(entity);
                if (res)
                    return BaseResponse<bool>.Success(true, "Form updated successfully");
                else
                    return BaseResponse<bool>.Success(false, "No Data Found");
            }
            catch (Exception ex)
            {
                return BaseResponse<bool>.Error("An error occurred while updated form: " + ex.Message);
            }
        }
    }
}
