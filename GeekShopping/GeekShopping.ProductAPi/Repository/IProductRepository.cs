using GeekShopping.ProductAPi.Data.ValueObjects;

namespace GeekShopping.ProductAPi.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductVO>> FindAll();
    Task<ProductVO> FindById(long id);
    Task<ProductVO> Create(ProductVO vo);
    Task<ProductVO> Update(ProductVO vo);
    Task<bool> Delete(long id);
}