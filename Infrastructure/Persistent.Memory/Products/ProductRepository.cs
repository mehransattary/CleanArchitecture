using Domain.Products;
using Domain.ProductsAggregate.Repository;

namespace Infrastructure.Persistent.Memory.Products;

public class ProductRepository : IProductRepository
{
    private readonly Context context;

    public ProductRepository(Context context)
    {
        this.context = context;
    }

    public void Add(Product product)
    {
        context.Products.Add(product);
    }

    public void Delete(Product product)
    {
        context.Products.Remove(product);   
    }

    public Product GetById(Guid id)
    {
        return context.Products.Find(x => x.Id == id);  
    }

    public List<Product> GetList()
    {
        return context.Products;
    }

    public void SaveChange()
    {
      //
    }

    public void Update(Product product)
    {
        var oldProduct = GetById(product.Id);
        context.Products.Remove(oldProduct);
        Add(product);
    }
}
