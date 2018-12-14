using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using HC.POSCloud.PosEnmus;

namespace HC.POSCloud.IntegralDetails
{
    /// <summary>
    /// 积分明细
    /// </summary>
    [Table("IntegralDetails")]
    public class IntegralDetail : Entity<Guid>, IHasCreationTime
    {

        /// <summary>
        /// 会员Id
        /// </summary>
        public virtual Guid? MemberId { get; set; }

        /// <summary>
        /// 初始积分
        /// </summary>
        public virtual decimal? InitialIntegral { get; set; }

        /// <summary>
        /// 发生积分（正、负）
        /// </summary>
        public virtual decimal? Integral { get; set; }

        /// <summary>
        /// 结束积分
        /// </summary>
        public virtual decimal? FinalIntegral { get; set; }

        /// <summary>
        /// 积分类型(枚举：购买商品、评价商品、抽奖消费)
        /// </summary>
        public virtual IntegralEnum? Type { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(500)]
        public virtual string Desc { get; set; }

        /// <summary>
        /// 店铺Id
        /// </summary>
        public virtual Guid? ShopId { get; set; }

        /// <summary>
        /// 引用Id 多个用逗号隔开，收费记录
        /// </summary>
        [StringLength(500)]
        public virtual string RefId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public virtual DateTime CreationTime { get; set; }
    }
}
