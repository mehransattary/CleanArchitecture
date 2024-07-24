using Domain.Products;

namespace Domain.ProductsAggregate.Repository;

public interface IProductRepository
{
    List<Product> GetList();
    Product GetById(Guid id);
    void Add(Product product);
    void Update(Product product);
    void Delete(Product product);
    void SaveChange();

}
