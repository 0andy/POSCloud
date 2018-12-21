

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using HC.POSCloud.Shops;


namespace HC.POSCloud.Shops.DomainService
{
    public interface IShopManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitShop();


        Task InitShopProductAsync(Guid shopId);

    }
}
