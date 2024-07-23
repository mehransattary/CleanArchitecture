using Application.Orders;
using Application.Products;
using Contracts;
using Domain.Orders;
using Domain.Products;
using Infrastructure.Persistent.Memory;
using Infrastructure.Persistent.Memory.Orders;
using Infrastructure.Persistent.Memory.Products;
using Infrastructure.Sms;
using Microsoft.Extensions.DependencyInjection;

namespace BootstrapperConfig;

public class ProjectBootstrapper
{
    public static void Init(IServiceCollection services)
    {
        services.AddSingleton<Context>();

        services.AddScoped<ISmsService, SmsService>();

        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IProductService, ProductService>();

        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
    }
}
