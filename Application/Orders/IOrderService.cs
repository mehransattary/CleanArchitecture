using Application.Orders.DTOs;

namespace Application.Orders;

public interface IOrderService
{
    void AddOrder(AddOrderDto addOrderDto);
    void Finally(FinallyOrderDto finallyOrderDto);
    OrderDto GetOrderById(int id);
    List<OrderDto> GetOrders();
}
