using Application.Orders.DTOs;
using Contracts;
using Domain.Orders;
using Domain.OrdersAggregate.Repository;

namespace Application.Orders;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly ISmsService smsService;
    public OrderService(IOrderRepository orderRepository, ISmsService smsService)
    {
        this.orderRepository = orderRepository;
        this.smsService = smsService;
    }

    public void AddOrder(AddOrderDto addOrderDto)
    {
        var order = new Order(addOrderDto.ProductId);
        orderRepository.Add(order);
        orderRepository.SaveChange();   
    }

    public void Finally(FinallyOrderDto finallyOrderDto)
    {
        var order =  orderRepository.GetById(finallyOrderDto.OrderId);
        order.Finally();
        orderRepository.Update(order);
        orderRepository.SaveChange();
        smsService.SendSms(new SmsBody()
        {
            Message ="Test" ,
            PhoneNumber ="09369944780"
        });
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
