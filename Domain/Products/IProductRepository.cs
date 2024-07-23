namespace Domain.Products;

public interface IProductRepository
{
    List<Product> GetList();
    Product GetById(Guid id);
    void Add(Product product);
    void Update(Product product);
    void Delete(Product product);
    void SaveChange();

}
