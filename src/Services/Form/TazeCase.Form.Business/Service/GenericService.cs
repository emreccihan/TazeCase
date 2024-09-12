using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Core.Entities;
using TazeCase.Form.Core.Repository;
using TazeCase.Form.Core.Service;
using TazeCase.Form.Core.Wrappers.Response;

namespace TazeCase.Form.Business.Service
{
    public class GenericService<TEntity, TInputDto, TOutputDto> : IGenericService<TEntity, TInputDto, TOutputDto>
        where TEntity : BaseEntity
    {
        private readonly IGenericRepository<TEntity> repository;
        private readonly IMapper mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<TOutputDto>> AddAsync(TInputDto entityDto)
        {
            try
            {
                var entity = this.mapper.Map<TEntity>(entityDto);
                var res = await repository.AddAsync(entity);
                var resDto = this.mapper.Map<TOutputDto>(res);
                return BaseResponse<TOutputDto>.Success(resDto, "Entity added successfully");
            }
            catch (Exception ex)
            {
                return BaseResponse<TOutputDto>.Error("An error occurred while adding entity: " + ex.Message);
            }
        }

        public async Task<BaseResponse<List<TOutputDto>>> GetAllAsync()
        {
            try
            {
                var res = await repository.GetAllAsync();
                var resDto = this.mapper.Map<List<TOutputDto>>(res);
                return BaseResponse<List<TOutputDto>>.Success(resDto, "Entities fetched successfully");
            }
            catch (Exception ex)
            {
                return BaseResponse<List<TOutputDto>>.Error("An error occurred while fetching entities: " + ex.Message);
            }
        }

        public async Task<BaseResponse<TOutputDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var res = await repository.GetByIdAsync(id);
                var resDto = this.mapper.Map<TOutputDto>(res);
                return BaseResponse<TOutputDto>.Success(resDto, "Entity fetched successfully");
            }
            catch (Exception ex)
            {
                return BaseResponse<TOutputDto>.Error("An error occurred while fetching entity: " + ex.Message);
            }
        }

        public async Task<BaseResponse<List<TOutputDto>>> GetFilteredAsync(int? limit = null, int? pageNumber = null, int? pageSize = null)
        {
            try
            {
                var res = await repository.GetFilteredAsync(limit, pageNumber, pageSize);
                var resDto = this.mapper.Map<List<TOutputDto>>(res);
                return BaseResponse<List<TOutputDto>>.Success(resDto, "Entities fetched successfully");
            }
            catch (Exception ex)
            {
                return BaseResponse<List<TOutputDto>>.Error("An error occurred while fetching entities: " + ex.Message);
            }
        }

        public async Task<BaseResponse<TOutputDto>> Update(Guid id, TInputDto entityDto)
        {
            try
            {
                var entity = this.mapper.Map<TEntity>(entityDto);
                // Assuming the repository has an Update method that accepts the entity with an Id.
                entity.Id = id; // Set the Id if necessary
                var res = await repository.Update(entity);
                var resDto = this.mapper.Map<TOutputDto>(res);
                return BaseResponse<TOutputDto>.Success(resDto, "Entity updated successfully");
            }
            catch (Exception ex)
            {
                return BaseResponse<TOutputDto>.Error("An error occurred while updating entity: " + ex.Message);
            }
        }

        public async Task<BaseResponse<bool>> Delete(Guid id)
        {
            try
            {
                var res = await repository.DeleteAsync(id);
                if (res)
                    return BaseResponse<bool>.Success(true, "Entity deleted successfully");
                else
                    return BaseResponse<bool>.Success(false, "No data found");
            }
            catch (Exception ex)
            {
                return BaseResponse<bool>.Error("An error occurred while deleting entity: " + ex.Message);
            }
        }
    }
}
