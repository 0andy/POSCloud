

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using HC.POSCloud;
using HC.POSCloud.Shops;
using HC.POSCloud.RetailProducts;
using HC.POSCloud.Products;
using Abp.AutoMapper;

namespace HC.POSCloud.Shops.DomainService
{
    /// <summary>
    /// Shop领域层的业务管理
    ///</summary>f
    public class ShopManager :POSCloudDomainServiceBase, IShopManager
    {
		
		private readonly IRepository<Shop, Guid> _repository;
        private readonly IRepository<RetailProduct, Guid> _retailProductrepository;
        private readonly IRepository<Product, Guid> _productrepository;

        /// <summary>
        /// Shop的构造方法
        ///</summary>
        public ShopManager(
			IRepository<Shop, Guid> repository,
            IRepository<RetailProduct, Guid> retailProductrepository,
            IRepository<Product, Guid> productrepository
            )
		{
			_repository =  repository;
            _retailProductrepository = retailProductrepository;
            _productrepository = productrepository;
        }


		/// <summary>
		/// 初始化
		///</summary>
		public void InitShop()
		{
			
		}

        public async Task InitShopProductAsync(Guid shopId)
        {
            var productList = await _productrepository.GetAll().Where(p => p.IsEnable == PosEnmus.EnableEnum.启用).AsNoTracking().ToListAsync();

            var shopProductList = productList.MapTo<List<RetailProduct>>();

            await _retailProductrepository.DeleteAsync(d => d.ShopId == shopId);

            shopProductList.ForEach(async (item) => 
            {
                item.ShopId = shopId;
                await _retailProductrepository.InsertAsync(item);
            });
        }
    }
}
