
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
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using HC.POSCloud.RetailProducts.Dtos;
using HC.POSCloud.RetailProducts;

namespace HC.POSCloud.RetailProducts
{
    /// <summary>
    /// RetailProduct应用层服务的接口方法
    ///</summary>
    public interface IRetailProductAppService : IApplicationService
    {
        /// <summary>
		/// 获取RetailProduct的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<RetailProductListDto>> GetPaged(GetRetailProductsInput input);


		/// <summary>
		/// 通过指定id获取RetailProductListDto信息
		/// </summary>
		Task<RetailProductListDto> GetById(EntityDto<Guid> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetRetailProductForEditOutput> GetForEdit(NullableIdDto<Guid> input);


        /// <summary>
        /// 添加或者修改RetailProduct的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateRetailProductInput input);


        /// <summary>
        /// 删除RetailProduct信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<Guid> input);


        /// <summary>
        /// 批量删除RetailProduct
        /// </summary>
        Task BatchDelete(List<Guid> input);


		/// <summary>
        /// 导出RetailProduct为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
