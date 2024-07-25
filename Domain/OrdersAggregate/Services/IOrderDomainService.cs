
namespace Domain.OrdersAggregate.Services;

//اگر کسب وکار ما نیاز به سرویس هایی داره که باید از اگریگیت های دیگه بخاد استفاده کنه باید از دامین سرویس استفاده کنیم.
public interface IOrderDomainService
{
    bool IsProductNotExist(Guid productId);
}
