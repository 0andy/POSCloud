

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using HC.POSCloud.Members;
using HC.POSCloud.PosEnmus;
using Abp.AutoMapper;

namespace HC.POSCloud.Members.Dtos
{
    [AutoMapFrom(typeof(Member))]
    public class MemberListDto : EntityDto<Guid>, IHasCreationTime
    {
        public string Name { get; set; }

        public SexEnum? Sex { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [Required(ErrorMessage = "Phone不能为空")]
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

        public string HeadImgUrlPic
        {
            get
            {
                if (string.IsNullOrEmpty(HeadImgUrl))
                {
                    return @"./assets/images/timg-4.jpeg";
                }
                return HeadImgUrl;
            }
            set
            {
                HeadImgUrl = value;
            }
        }

        /// <summary>
        /// UserType
        /// </summary>
        public UserTypeEnum? UserType { get; set; }

        public string UserTypeName
        {
            get
            {
                return UserType.ToString();
            }
        }

        /// <summary>
        /// BindStatus
        /// </summary>
        public BindStatus? BindStatus { get; set; }

        public string BindStatusName
        {
            get
            {
                return BindStatus.ToString();
            }
        }

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