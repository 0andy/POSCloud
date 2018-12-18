
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using HC.POSCloud.IntegralDetails;
using HC.POSCloud.IntegralDetails.Dtos;
using HC.POSCloud.IntegralDetails.DomainService;
using HC.POSCloud.IntegralDetails.Authorization;


namespace HC.POSCloud.IntegralDetails
{
    /// <summary>
    /// IntegralDetail应用层服务的接口实现方法  
    ///</summary>
    public class IntegralDetailAppService : POSCloudAppServiceBase, IIntegralDetailAppService
    {
        private readonly IRepository<IntegralDetail, Guid> _entityRepository;

        private readonly IIntegralDetailManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public IntegralDetailAppService(
        IRepository<IntegralDetail, Guid> entityRepository
        ,IIntegralDetailManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取IntegralDetail的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<IntegralDetailListDto>> GetPagedIntegralListByIdAsync(GetIntegralDetailsInput input)
		{
		    var query = _entityRepository.GetAll().Where(v=>v.MemberId == input.MemberId);
			var count = await query.CountAsync();
			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();
			var entityListDtos =entityList.MapTo<List<IntegralDetailListDto>>();
			return new PagedResultDto<IntegralDetailListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取IntegralDetailListDto信息
		/// </summary>
		[AbpAuthorize(IntegralDetailPermissions.Query)] 
		public async Task<IntegralDetailListDto> GetById(EntityDto<Guid> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<IntegralDetailListDto>();
		}

		/// <summary>
		/// 获取编辑 IntegralDetail
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(IntegralDetailPermissions.Create,IntegralDetailPermissions.Edit)]
		public async Task<GetIntegralDetailForEditOutput> GetForEdit(NullableIdDto<Guid> input)
		{
			var output = new GetIntegralDetailForEditOutput();
IntegralDetailEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<IntegralDetailEditDto>();

				//integralDetailEditDto = ObjectMapper.Map<List<integralDetailEditDto>>(entity);
			}
			else
			{
				editDto = new IntegralDetailEditDto();
			}

			output.IntegralDetail = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改IntegralDetail的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(IntegralDetailPermissions.Create,IntegralDetailPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateIntegralDetailInput input)
		{

			if (input.IntegralDetail.Id.HasValue)
			{
				await Update(input.IntegralDetail);
			}
			else
			{
				await Create(input.IntegralDetail);
			}
		}


		/// <summary>
		/// 新增IntegralDetail
		/// </summary>
		[AbpAuthorize(IntegralDetailPermissions.Create)]
		protected virtual async Task<IntegralDetailEditDto> Create(IntegralDetailEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <IntegralDetail>(input);
            var entity=input.MapTo<IntegralDetail>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<IntegralDetailEditDto>();
		}

		/// <summary>
		/// 编辑IntegralDetail
		/// </summary>
		[AbpAuthorize(IntegralDetailPermissions.Edit)]
		protected virtual async Task Update(IntegralDetailEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除IntegralDetail信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(IntegralDetailPermissions.Delete)]
		public async Task Delete(EntityDto<Guid> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除IntegralDetail的方法
		/// </summary>
		[AbpAuthorize(IntegralDetailPermissions.BatchDelete)]
		public async Task BatchDelete(List<Guid> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出IntegralDetail为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


