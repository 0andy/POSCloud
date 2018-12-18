
using AutoMapper;
using HC.POSCloud.IntegralDetails;
using HC.POSCloud.IntegralDetails.Dtos;

namespace HC.POSCloud.IntegralDetails.Mapper
{

	/// <summary>
    /// 配置IntegralDetail的AutoMapper
    /// </summary>
	internal static class IntegralDetailMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <IntegralDetail,IntegralDetailListDto>();
            configuration.CreateMap <IntegralDetailListDto,IntegralDetail>();

            configuration.CreateMap <IntegralDetailEditDto,IntegralDetail>();
            configuration.CreateMap <IntegralDetail,IntegralDetailEditDto>();

        }
	}
}
