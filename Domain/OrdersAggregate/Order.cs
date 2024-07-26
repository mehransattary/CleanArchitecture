using Domain.OrdersAggregate;
using Domain.OrdersAggregate.Events;
using Domain.OrdersAggregate.Services;
using Domain.Shared;

namespace Domain.Orders;

public class Order : AggregateRoot
{
    public long Id { get; private set; }
    public long UserId { get; private set; }
    public bool IsFinally { get; set; }
    public int TotalItems { get; set; }
    public DateTime FinalyDate { get; set; }
    public ICollection<OrderItem> Items { get; private set; }

    public Order(long userId)
    {
        UserId = userId;
    }

    public void AddItem(Guid productId, int count, int price, IOrderDomainService orderDomainService)
    {
        if (orderDomainService.IsProductNotExist(productId))
            throw new Exception("Is Product Not Exist");

        Items.Add(new OrderItem(Id, productId, count, Money.FromTooman(price)));
        TotalItems += count;
    }

    public void RemoveItem(Guid productId, int count, int price)
    {
        if (Items.Any(x => x.ProductId == productId))
            return;

        var item = Items.FirstOrDefault(x=>x.ProductId == productId);

        if(item == null)
            throw new Exception("item is null");

        Items.Remove(item);
        TotalItems -= count;
    }

    public void Finally()
    {
        IsFinally = true;
        FinalyDate = DateTime.Now;
        AddDomainEvent(new OrderFinalized(Id, UserId));
    }

}
