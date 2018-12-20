

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using HC.POSCloud.Shops;
using Abp.AutoMapper;

namespace HC.POSCloud.Shops.Dtos
{
    [AutoMapFrom(typeof(Shop))]
    public class ShopListDto : EntityDto<Guid> 
    {

        
		/// <summary>
		/// Name
		/// </summary>
		public string Name { get; set; }



		/// <summary>
		/// RetailId
		/// </summary>
		public Guid? RetailId { get; set; }



		/// <summary>
		/// RetailName
		/// </summary>
		public string RetailName { get; set; }



		/// <summary>
		/// LicenseKey
		/// </summary>
		public string LicenseKey { get; set; }



		/// <summary>
		/// AuthorizationCode
		/// </summary>
		public string AuthorizationCode { get; set; }



		/// <summary>
		/// Aaddress
		/// </summary>
		public string Aaddress { get; set; }



		/// <summary>
		/// QRCode
		/// </summary>
		public string QRCode { get; set; }



		/// <summary>
		/// Longitude
		/// </summary>
		public float? Longitude { get; set; }



		/// <summary>
		/// Latitude
		/// </summary>
		public float? Latitude { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime? CreationTime { get; set; }



		/// <summary>
		/// CreatorUserId
		/// </summary>
		public Guid? CreatorUserId { get; set; }



		/// <summary>
		/// LastModificationTime
		/// </summary>
		public DateTime? LastModificationTime { get; set; }



		/// <summary>
		/// LastModifierUserId
		/// </summary>
		public Guid? LastModifierUserId { get; set; }




    }
}