using Domain.Orders;
using Domain.Products;

namespace Infrastructure.Persistent.Memory;

public  class Context
{
    public List<Product> Products { get; set; }
    public List<Order> Orders { get; set; }

}
