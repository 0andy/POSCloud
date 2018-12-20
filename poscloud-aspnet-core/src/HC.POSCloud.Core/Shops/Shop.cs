using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HC.POSCloud.Shops
{
    [Table("Shops")]
    public class Shop : Entity<Guid> //注意修改主键Id数据类型
    {
        /// <summary>
        /// 店铺名称
        /// </summary>
        [StringLength(100)]
        public virtual string Name { get; set; }
        /// <summary>
        /// 零售客户Id
        /// </summary>
        public virtual Guid? RetailId { get; set; }
        /// <summary>
        /// 零售客户名
        /// </summary>
        [StringLength(50)]
        public virtual string RetailName { get; set; }
        /// <summary>
        /// 专卖证号
        /// </summary>
        [StringLength(50)]
        public virtual string LicenseKey { get; set; }
        /// <summary>
        /// 授权码
        /// </summary>
        [StringLength(100)]
        public virtual string AuthorizationCode { get; set; }
        /// <summary>
        /// 店铺地址（配置项）
        /// </summary>
        [StringLength(200)]
        public virtual string Aaddress { get; set; }
        /// <summary>
        /// 店铺二维码 （支付入库 需要联网）
        /// </summary>
        [StringLength(500)]
        public virtual string QRCode { get; set; }
        /// <summary>
        /// 经度（配置项）
        /// </summary>
        public virtual float? Longitude { get; set; }
        /// <summary>
        /// 纬度（配置项）
        /// </summary>
        public virtual float? Latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? CreationTime { get; set; }
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
