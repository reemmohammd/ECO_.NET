using ECommerce_2.DAL.Repos;
using ECommerce_2.DAL.Repos.OrdersRepo;
using ECommerce_2.DAL.Repos.ProducrsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL;

public interface IUnitOfWork
{
    public IProductsRepo productRepositary { get; }
    public ICartsRepo cartRepository { get; }
    public IOrdersRepo orderRepositary { get; }

    void SaveChanges();
}
