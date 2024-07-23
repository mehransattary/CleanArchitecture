using Domain.Orders;
using Domain.Products;

namespace Infrastructure.Persistent.Memory;

public  class Context
{
    public List<Product> Products { get; set; } =new List<Product>() { new Product("Test1",25000) };
    public List<Order> Orders { get; set; }

}
