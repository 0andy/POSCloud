
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


using HC.POSCloud.Shops;
using HC.POSCloud.Shops.Dtos;
using HC.POSCloud.Retailers;

namespace HC.POSCloud.Shops
{
    /// <summary>
    /// Shop应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ShopAppService : POSCloudAppServiceBase, IShopAppService
    {
        private readonly IRepository<Shop, Guid> _entityRepository;
        private readonly IRepository<Retailer, Guid> _retailerRepository;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ShopAppService(
        IRepository<Shop, Guid> entityRepository,
        IRepository<Retailer, Guid> retailerRepository
        )
        {
            _entityRepository = entityRepository;
            _retailerRepository = retailerRepository;
        }


        /// <summary>
        /// 获取Shop的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		 
        public async Task<PagedResultDto<ShopListDto>> GetPaged(GetShopsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<ShopListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<ShopListDto>>();

			return new PagedResultDto<ShopListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取ShopListDto信息
		/// </summary>
		 
		public async Task<ShopListDto> GetById(EntityDto<Guid> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<ShopListDto>();
		}

		/// <summary>
		/// 获取编辑 Shop
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task<GetShopForEditOutput> GetForEdit(NullableIdDto<Guid> input)
		{
			var output = new GetShopForEditOutput();
ShopEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<ShopEditDto>();

				//shopEditDto = ObjectMapper.Map<List<shopEditDto>>(entity);
			}
			else
			{
				editDto = new ShopEditDto();
			}

			output.Shop = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改Shop的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task CreateOrUpdate(CreateOrUpdateShopInput input)
		{

			if (input.Shop.Id.HasValue)
			{
				await Update(input.Shop);
			}
			else
			{
				await Create(input.Shop);
			}
		}


		/// <summary>
		/// 新增Shop
		/// </summary>
		
		protected virtual async Task<ShopEditDto> Create(ShopEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Shop>(input);
            var entity=input.MapTo<Shop>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<ShopEditDto>();
		}

		/// <summary>
		/// 编辑Shop
		/// </summary>
		
		protected virtual async Task Update(ShopEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除Shop信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task Delete(EntityDto<Guid> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除Shop的方法
		/// </summary>
		
		public async Task BatchDelete(List<Guid> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        public async Task<ShopListDto> SynInitShopAsync(string licenseKey)
        {
            var exists = await _entityRepository.GetAll().AnyAsync(e => e.LicenseKey == licenseKey);
            if (exists) //存在
            {
                var shop = await _entityRepository.GetAll().Where(e => e.LicenseKey == licenseKey).FirstAsync();
                return shop.MapTo<ShopListDto>();
            }
            else
            {
                var retailer = await _retailerRepository.GetAll().Where(r => r.LicenseKey == licenseKey).AsNoTracking().FirstOrDefaultAsync();
                if (retailer != null)
                {
                    Shop shop = new Shop();
                    shop.LicenseKey = retailer.LicenseKey;
                    shop.Name = retailer.Name;
                    shop.RetailId = retailer.Id;
                    shop.RetailName = retailer.Name;
                    shop.CreationTime = DateTime.Now;
                    shop.AuthorizationCode = retailer.AuthorizationCode;
                    shop.Aaddress = retailer.BusinessAddress;
                    var shopId = await _entityRepository.InsertAndGetIdAsync(shop);
                    shop.Id = shopId;
                    return shop.MapTo<ShopListDto>();
                }

                return null;
            }
        }

        /// <summary>
        /// 导出Shop为excel表,等待开发。
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


