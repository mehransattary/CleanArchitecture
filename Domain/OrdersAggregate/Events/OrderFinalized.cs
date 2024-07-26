
using Domain.Shared;

namespace Domain.OrdersAggregate.Events;

public class OrderFinalized : BaseDomainEvent
{
    public OrderFinalized(long orderId, long userId)
    {
        OrderId = orderId;
        UserId = userId;
    }

    public long OrderId { get; set; }
    public long UserId { get; set; }
}
