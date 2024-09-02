using AutoMapper;
using GeekShopping.ProductAPi.Data.ValueObjects;
using GeekShopping.ProductAPi.Model;
using GeekShopping.ProductAPi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPi.Repository;

public class ProductRepository : IProductRepository
{
    private readonly MySQLContext _context;
    private IMapper _mapper;

    public ProductRepository(MySQLContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;  
    }
    
    public async Task<IEnumerable<ProductVO>> FindAll()
    {
        List<Product> products = await _context.Products.ToListAsync();
        return _mapper.Map<List<ProductVO>>(products);
    }

    public async Task<ProductVO> FindById(long id)
    {
        Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<ProductVO>(product);
    }

    public Task<ProductVO> Create(ProductVO vo)
    {
        throw new NotImplementedException();
    }

    public Task<ProductVO> Update(ProductVO vo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(long id)
    {
        throw new NotImplementedException();
    }
}