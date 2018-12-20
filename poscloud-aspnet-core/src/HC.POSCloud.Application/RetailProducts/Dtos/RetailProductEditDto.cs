
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using HC.POSCloud.RetailProducts;

namespace  HC.POSCloud.RetailProducts.Dtos
{
    public class RetailProductEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id { get; set; }         


        
		/// <summary>
		/// ShopId
		/// </summary>
		[Required(ErrorMessage="ShopId不能为空")]
		public Guid ShopId { get; set; }



		/// <summary>
		/// BarCode
		/// </summary>
		public string BarCode { get; set; }



		/// <summary>
		/// Name
		/// </summary>
		[Required(ErrorMessage="Name不能为空")]
		public string Name { get; set; }



		/// <summary>
		/// CategoryId
		/// </summary>
		[Required(ErrorMessage="CategoryId不能为空")]
		public int CategoryId { get; set; }



		/// <summary>
		/// Grade
		/// </summary>
		public int? Grade { get; set; }



		/// <summary>
		/// RetailPrice
		/// </summary>
		public decimal? RetailPrice { get; set; }



		/// <summary>
		/// PurchasePrice
		/// </summary>
		public decimal? PurchasePrice { get; set; }



		/// <summary>
		/// SellPrice
		/// </summary>
		public decimal? SellPrice { get; set; }



		/// <summary>
		/// IsEnableMember
		/// </summary>
		public bool? IsEnableMember { get; set; }



		/// <summary>
		/// MemberPrice
		/// </summary>
		public decimal? MemberPrice { get; set; }



		/// <summary>
		/// Unit
		/// </summary>
		public string Unit { get; set; }



		/// <summary>
		/// PinYinCode
		/// </summary>
		public string PinYinCode { get; set; }



		/// <summary>
		/// Lable
		/// </summary>
		public string Lable { get; set; }



		/// <summary>
		/// Stock
		/// </summary>
		public int? Stock { get; set; }



		/// <summary>
		/// IsEnable
		/// </summary>
		public bool? IsEnable { get; set; }



		/// <summary>
		/// Desc
		/// </summary>
		public string Desc { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		[Required(ErrorMessage="CreationTime不能为空")]
		public DateTime CreationTime { get; set; }



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