
using AutoMapper;
using HC.POSCloud.RetailProducts;
using HC.POSCloud.RetailProducts.Dtos;

namespace HC.POSCloud.RetailProducts.Mapper
{

	/// <summary>
    /// 配置RetailProduct的AutoMapper
    /// </summary>
	internal static class RetailProductMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <RetailProduct,RetailProductListDto>();
            configuration.CreateMap <RetailProductListDto,RetailProduct>();

            configuration.CreateMap <RetailProductEditDto,RetailProduct>();
            configuration.CreateMap <RetailProduct,RetailProductEditDto>();

        }
	}
}
