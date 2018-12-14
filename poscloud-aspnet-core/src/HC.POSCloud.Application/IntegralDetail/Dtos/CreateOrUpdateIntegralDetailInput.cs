

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HC.POSCloud.IntegralDetails;

namespace HC.POSCloud.IntegralDetails.Dtos
{
    public class CreateOrUpdateIntegralDetailInput
    {
        [Required]
        public IntegralDetailEditDto IntegralDetail { get; set; }

    }
}