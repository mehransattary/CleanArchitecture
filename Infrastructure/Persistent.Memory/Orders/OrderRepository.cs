using Domain.Orders;
using Domain.OrdersAggregate.Repository;

namespace Infrastructure.Persistent.Memory.Orders;

public class OrderRepository : IOrderRepository
{
    private readonly Context context;

    public OrderRepository(Context context)
    {
        this.context = context;
    }

    public void Add(Order order)
    {
        context.Orders.Add(order);
    }

    public Order GetById(long id)
    {
       return  context.Orders.Find(x=>x.Id == id);
    }

    public List<Order> GetList()
    {
        return context.Orders;
    }

    public void SaveChange()
    {
      //
    }

    public void Update(Order order)
    {
        var oldorder = GetById(order.Id);
        context.Orders.Remove(oldorder);
        Add(oldorder);
    }
}
