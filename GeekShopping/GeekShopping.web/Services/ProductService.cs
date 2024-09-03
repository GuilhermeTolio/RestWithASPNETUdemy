using GeekShopping.web.Models;
using GeekShopping.web.Services.IServices;
using GeekShopping.web.Utils;

namespace GeekShopping.web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    public const string BasePath = "api/v1/products";
    
    public async Task<IEnumerable<ProductModel>> FindAllProducts()
    {
        var response = await _client.GetAsync(BasePath);
        return await response.ReadContentAs<List<ProductModel>>();
    }

    public async Task<ProductModel> FindProductById(long id)
    {
        var response = await _client.GetAsync($"{BasePath}/{id}");
        return await response.ReadContentAs<ProductModel>();
    }

    public Task<ProductModel> CreateProduct(ProductModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ProductModel> UpdateProduct(ProductModel model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProductById(long id)
    {
        throw new NotImplementedException();
    }
}