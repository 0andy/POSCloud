

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using HC.POSCloud.IntegralDetails;
using HC.POSCloud.PosEnmus;

namespace HC.POSCloud.IntegralDetails.Dtos
{
    public class IntegralDetailListDto : EntityDto<Guid>,IHasCreationTime 
    {

        
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

        public string TypeName
        {
            get
            {
                return Type.ToString();
            }
        }

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