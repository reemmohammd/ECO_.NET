using ECommerce_2.DAL.Context;
using ECommerce_2.DAL.Repos;
using ECommerce_2.DAL.Repos.OrdersRepo;
using ECommerce_2.DAL.Repos.ProducrsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly AbilityContext _Context;
    public UnitOfWork(AbilityContext DbContext, IProductsRepo productsRepos, ICartsRepo cartsRepo, IOrdersRepo ordersRepo)
    {
        _Context = DbContext;
        productRepositary = productsRepos;
        cartRepository = cartsRepo;
        orderRepositary = ordersRepo;
    }
    public IProductsRepo productRepositary { get; }
    public ICartsRepo cartRepository { get; }
    public IOrdersRepo orderRepositary { get; }

    public void SaveChanges()
    {
    }
}
