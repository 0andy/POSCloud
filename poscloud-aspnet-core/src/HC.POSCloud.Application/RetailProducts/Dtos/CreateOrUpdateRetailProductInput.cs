

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HC.POSCloud.RetailProducts;

namespace HC.POSCloud.RetailProducts.Dtos
{
    public class CreateOrUpdateRetailProductInput
    {
        [Required]
        public RetailProductEditDto RetailProduct { get; set; }

    }
}