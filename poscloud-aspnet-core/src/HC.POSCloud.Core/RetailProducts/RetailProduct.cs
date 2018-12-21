using Abp.Domain.Entities;
using HC.POSCloud.PosEnmus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HC.POSCloud.RetailProducts
{
    [Table("RetailProducts")]
    public class RetailProduct : Entity<Guid> //注意修改主键Id数据类型
    {
        /// <summary>
        /// 店铺Id
        /// </summary>
        [Required]
        public virtual Guid ShopId { get; set; }
        /// <summary>
        /// 条码
        /// </summary>
        [StringLength(50)]
        public virtual string BarCode { get; set; }
        /// <summary>
        /// 商品名称规格
        /// </summary>
        [StringLength(200)]
        [Required]
        public virtual string Name { get; set; }
        /// <summary>
        /// 产品分类（外键Id：烟、酒、饮料、副食、其它）
        /// </summary>
        [Required]
        public virtual int CategoryId { get; set; }
        /// <summary>
        /// 卷烟等级类（枚举：1-5类烟 一类烟-五类烟）
        /// </summary>
        public virtual int? Grade { get; set; }
        /// <summary>
        /// 零售指导价
        /// </summary>
        public virtual decimal? RetailPrice { get; set; }
        /// <summary>
        /// 进货单价
        /// </summary>
        public virtual decimal? PurchasePrice { get; set; }
        /// <summary>
        /// 销售单价
        /// </summary>
        public virtual decimal? SellPrice { get; set; }
        /// <summary>
        /// 是否启用会员价（默认不启用）
        /// </summary>
        public virtual bool? IsEnableMember { get; set; }
        /// <summary>
        /// 会员价
        /// </summary>
        public virtual decimal? MemberPrice { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [StringLength(50)]
        public virtual string Unit { get; set; }
        /// <summary>
        /// 拼音码
        /// </summary>
        [StringLength(50)]
        public virtual string PinYinCode { get; set; }
        /// <summary>
        /// 商品标签
        /// </summary>
        [StringLength(50)]
        public virtual string Lable { get; set; }
        /// <summary>
        /// 商品库存
        /// </summary>
        public virtual int? Stock { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual EnableEnum IsEnable { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        [StringLength(500)]
        public virtual string Desc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public virtual DateTime CreationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? CreatorUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? LastModifierUserId { get; set; }
    }

}
