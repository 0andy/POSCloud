
using Abp.Runtime.Validation;
using HC.POSCloud.Dtos;
using HC.POSCloud.Products;

namespace HC.POSCloud.Products.Dtos
{
    public class GetProductsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 树节点
        /// </summary>
        public string NodeKey { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }

        public string Filter { get; set; }
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
