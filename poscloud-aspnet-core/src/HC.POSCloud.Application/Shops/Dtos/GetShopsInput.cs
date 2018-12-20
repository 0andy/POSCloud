
using Abp.Runtime.Validation;
using HC.POSCloud.Dtos;
using HC.POSCloud.Shops;

namespace HC.POSCloud.Shops.Dtos
{
    public class GetShopsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
