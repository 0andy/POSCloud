
using Abp.Runtime.Validation;
using HC.POSCloud.Dtos;
using HC.POSCloud.IntegralDetails;
using System;

namespace HC.POSCloud.IntegralDetails.Dtos
{
    public class GetIntegralDetailsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {
        public Guid MemberId { get; set; }
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
