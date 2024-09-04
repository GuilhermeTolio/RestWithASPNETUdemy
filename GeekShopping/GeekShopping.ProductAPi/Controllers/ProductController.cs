
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
        _repository = repository;
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
    
    [HttpPost]
    public async Task<ActionResult<ProductVo>> Create([FromBody]ProductVo vo)
    {
        if (vo == null) return BadRequest();
        var product = await _repository.Create(vo);
        return Ok(product);
    }
    
    [HttpPut]
    public async Task<ActionResult<ProductVo>> Update([FromBody]ProductVo vo)
    {
        if (vo == null) return BadRequest();
        var product = await _repository.Update(vo);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromBody]long id)
    {
        var status = await _repository.Delete(id);
        if (!status) return BadRequest();
        return Ok(status);
    }
    
}