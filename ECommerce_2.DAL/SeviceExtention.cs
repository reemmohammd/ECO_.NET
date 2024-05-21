
using ECommerce_2.DAL.Repos;
using ECommerce_2.DAL.Repos.OrdersRepo;
using ECommerce_2.DAL.Repos.ProducrsRepo;


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL;

public static class SeviceExtention
{
    public static void AddDALServices(this IServiceCollection services,
            IConfiguration configuration)
    {
        services.AddScoped<ICartsRepo,CartsRepo>();

        services.AddScoped<IOrdersRepo, OrdersRepo>();

        services.AddScoped<IProductsRepo, ProductsRepo>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}

