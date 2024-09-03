
using GeekShopping.ProductAPi.Data.ValueObjects;
using GeekShopping.ProductAPi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository ?? throw new ArgumentException(nameof(repository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductVo>>> FindAll()
    {
        var products = await _repository.FindAll();
        return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductVo>> FindById(long id)
    {
        var product = await _repository.FindById(id);
        if (product.Id <= 0) return NotFound();
        return Ok(product);
    }

    
}