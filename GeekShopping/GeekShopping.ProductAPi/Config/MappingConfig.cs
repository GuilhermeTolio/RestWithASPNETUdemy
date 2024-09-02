using AutoMapper;
using GeekShopping.ProductAPi.Data.ValueObjects;
using GeekShopping.ProductAPi.Model;

namespace GeekShopping.ProductAPi.Config;

public class MappingConfig
{
    public static MapperConfiguration RegisterMapps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductVO, Product>();
            config.CreateMap<Product, ProductVO>();
        });
        return mappingConfig;
    }
}