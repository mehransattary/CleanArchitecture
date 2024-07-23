using Application.Orders.DTOs;
using Domain.Orders;

namespace Application.Orders;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public void AddOrder(AddOrderDto addOrderDto)
    {
        var order = new Order(addOrderDto.ProductId, addOrderDto.Count, addOrderDto.Price);
        orderRepository.Add(order);
        orderRepository.SaveChange();   
    }

    public void Finally(FinallyOrderDto finallyOrderDto)
    {
        var order =  orderRepository.GetById(finallyOrderDto.OrderId);
        order.Finally();
        orderRepository.Update(order);
        orderRepository.SaveChange();
    }

    public OrderDto GetOrderById(int id)
    {
        var order = orderRepository.GetById(id);

        var orderDto = new OrderDto
        {
            Count = order.Count,
            Price = order.Price,
            Id = order.Id,
            ProductId = order.ProductId
        };

        return orderDto;
    }

    public List<OrderDto> GetOrders()
    {
        var orders = orderRepository.GetList()
                                    .Select(order  => new OrderDto
                                    {
                                        Count = order.Count,
                                        Price = order.Price,
                                        Id = order.Id,
                                        ProductId = order.ProductId
                                    })
                                    .ToList();

        return orders;
    }
}
