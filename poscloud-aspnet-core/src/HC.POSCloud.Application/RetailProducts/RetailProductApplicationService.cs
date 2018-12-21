
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


using HC.POSCloud.RetailProducts;
using HC.POSCloud.RetailProducts.Dtos;




namespace HC.POSCloud.RetailProducts
{
    /// <summary>
    /// RetailProduct应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class RetailProductAppService : POSCloudAppServiceBase, IRetailProductAppService
    {
        private readonly IRepository<RetailProduct, Guid> _entityRepository;

        

        /// <summary>
        /// 构造函数 
        ///</summary>
        public RetailProductAppService(
        IRepository<RetailProduct, Guid> entityRepository
        
        )
        {
            _entityRepository = entityRepository; 
            
        }


        /// <summary>
        /// 获取RetailProduct的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		 
        public async Task<PagedResultDto<RetailProductListDto>> GetPaged(GetRetailProductsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<RetailProductListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<RetailProductListDto>>();

			return new PagedResultDto<RetailProductListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取RetailProductListDto信息
		/// </summary>
		 
		public async Task<RetailProductListDto> GetById(EntityDto<Guid> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<RetailProductListDto>();
		}

		/// <summary>
		/// 获取编辑 RetailProduct
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task<GetRetailProductForEditOutput> GetForEdit(NullableIdDto<Guid> input)
		{
			var output = new GetRetailProductForEditOutput();
            RetailProductEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<RetailProductEditDto>();

				//retailProductEditDto = ObjectMapper.Map<List<retailProductEditDto>>(entity);
			}
			else
			{
				editDto = new RetailProductEditDto();
			}

			output.RetailProduct = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改RetailProduct的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task CreateOrUpdate(CreateOrUpdateRetailProductInput input)
		{

			if (input.RetailProduct.Id.HasValue)
			{
				await Update(input.RetailProduct);
			}
			else
			{
				await Create(input.RetailProduct);
			}
		}


		/// <summary>
		/// 新增RetailProduct
		/// </summary>
		
		protected virtual async Task<RetailProductEditDto> Create(RetailProductEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <RetailProduct>(input);
            var entity=input.MapTo<RetailProduct>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<RetailProductEditDto>();
		}

		/// <summary>
		/// 编辑RetailProduct
		/// </summary>
		
		protected virtual async Task Update(RetailProductEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除RetailProduct信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task Delete(EntityDto<Guid> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除RetailProduct的方法
		/// </summary>
		
		public async Task BatchDelete(List<Guid> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        public async Task<List<RetailProductSynDto>> GetRetailProductSynAsync(int skipCount, Guid shopId)
        {
            var qurey = _entityRepository.GetAll().Where(s => s.ShopId == shopId).OrderBy(e => e.CreationTime);
            var plist = await qurey.Skip(skipCount).Take(2000).ToListAsync();//每次最多获取2000条数据
            return plist.MapTo<List<RetailProductSynDto>>();
        }


        /// <summary>
        /// 导出RetailProduct为excel表,等待开发。
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


