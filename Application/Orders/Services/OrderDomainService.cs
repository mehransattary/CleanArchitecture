using Domain.OrdersAggregate.Services;
using Domain.ProductsAggregate.Repository;

namespace Application.Orders.Services;

public class OrderDomainService : IOrderDomainService
{
    private readonly IProductRepository productRepository;

    public OrderDomainService(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public bool IsProductNotExist(Guid productId)
    {
        var productIsExist = productRepository.IsProductExist(productId);

        return !productIsExist;
    }
}
