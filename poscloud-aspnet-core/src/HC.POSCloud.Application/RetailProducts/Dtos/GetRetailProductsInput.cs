
using Abp.Runtime.Validation;
using HC.POSCloud.Dtos;
using HC.POSCloud.RetailProducts;

namespace HC.POSCloud.RetailProducts.Dtos
{
    public class GetRetailProductsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
