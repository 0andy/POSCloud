
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using HC.POSCloud.IntegralDetails;
using HC.POSCloud.PosEnmus;

namespace  HC.POSCloud.IntegralDetails.Dtos
{
    public class IntegralDetailEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id { get; set; }         


        
		/// <summary>
		/// MemberId
		/// </summary>
		public Guid? MemberId { get; set; }



		/// <summary>
		/// InitialIntegral
		/// </summary>
		public decimal? InitialIntegral { get; set; }



		/// <summary>
		/// Integral
		/// </summary>
		public decimal? Integral { get; set; }



		/// <summary>
		/// FinalIntegral
		/// </summary>
		public decimal? FinalIntegral { get; set; }



		/// <summary>
		/// Type
		/// </summary>
		public IntegralEnum? Type { get; set; }



		/// <summary>
		/// Desc
		/// </summary>
		public string Desc { get; set; }



		/// <summary>
		/// ShopId
		/// </summary>
		public Guid? ShopId { get; set; }



		/// <summary>
		/// RefId
		/// </summary>
		public string RefId { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		[Required(ErrorMessage="CreationTime不能为空")]
		public DateTime CreationTime { get; set; }




    }
}