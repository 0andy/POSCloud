
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using HC.POSCloud.Members;
using HC.POSCloud.PosEnmus;

namespace  HC.POSCloud.Members.Dtos
{
    public class MemberEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id { get; set; }


        [Required(ErrorMessage = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sex")]
        public SexEnum Sex { get; set; }
        /// <summary>
        /// Phone
        /// </summary>
        [Required(ErrorMessage="Phone不能为空")]
		public string Phone { get; set; }



		/// <summary>
		/// NickName
		/// </summary>
		public string NickName { get; set; }



		/// <summary>
		/// OpenId
		/// </summary>
		public string OpenId { get; set; }



		/// <summary>
		/// HeadImgUrl
		/// </summary>
		public string HeadImgUrl { get; set; }



		/// <summary>
		/// UserType
		/// </summary>
		public UserTypeEnum? UserType { get; set; }



		/// <summary>
		/// BindStatus
		/// </summary>
		public BindStatus? BindStatus { get; set; }



		/// <summary>
		/// BindTime
		/// </summary>
		public DateTime? BindTime { get; set; }



		/// <summary>
		/// UnBindTime
		/// </summary>
		public DateTime? UnBindTime { get; set; }



		/// <summary>
		/// Integral
		/// </summary>
		public int? Integral { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }




    }
}