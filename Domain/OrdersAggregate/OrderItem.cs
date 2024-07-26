using Domain.Shared;

namespace Domain.OrdersAggregate;

public class OrderItem : BaseEntity
{
    public OrderItem(long orderId, Guid productId, int count, Money price)
    { 
        OrderId = orderId;
        ProductId = productId;
        Count = count;
        Price = price;
    }

    public long Id { get; private set; }
    public long OrderId { get;protected set; }
    public Guid ProductId { get; protected set; }
    public int Count { get; private set; }
    public Money Price { get; private set; }

}
