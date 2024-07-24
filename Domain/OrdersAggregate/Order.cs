using Domain.OrdersAggregate;
using Domain.Shared;

namespace Domain.Orders;

public class Order
{
    public long Id { get; private set; }
    public Guid ProductId { get; private set; }
    public bool IsFinally { get; set; }
    public int TotalItems { get; set; }
    public DateTime FinalyDate { get; set; }
    public ICollection<OrderItem> Items { get; private set; }

    public Order(Guid productId)
    {
        ProductId = productId;
    }

    public void AddItem(Guid productId, int count, int price)
    {
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
    }

}
