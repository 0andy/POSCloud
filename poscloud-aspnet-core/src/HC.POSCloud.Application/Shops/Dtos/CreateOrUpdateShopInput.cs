

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HC.POSCloud.Shops;

namespace HC.POSCloud.Shops.Dtos
{
    public class CreateOrUpdateShopInput
    {
        [Required]
        public ShopEditDto Shop { get; set; }

    }
}