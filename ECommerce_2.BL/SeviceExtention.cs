using ECommerce_2.BL.Manager.Cart;
using ECommerce_2.BL.Manager.Order;
using ECommerce_2.BL.Manager.Product;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.BL;

public static class SeviceExtention
{
    public static void AddBLServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderManager, OrderManeger>();
        services.AddScoped<IProductManager, ProductManeger>();
        services.AddScoped<ICartManager, CartManeger>();

    }
}
