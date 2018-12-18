

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using HC.POSCloud.IntegralDetails;


namespace HC.POSCloud.IntegralDetails.DomainService
{
    public interface IIntegralDetailManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitIntegralDetail();



		 
      
         

    }
}
