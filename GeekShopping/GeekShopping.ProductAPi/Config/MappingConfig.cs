using AutoMapper;
using GeekShopping.ProductAPi.Data.ValueObjects;
using GeekShopping.ProductAPi.Model;

namespace GeekShopping.ProductAPi.Config;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductVo, Product>();
            config.CreateMap<Product, ProductVo>();
        });
        return mappingConfig;
    }
}