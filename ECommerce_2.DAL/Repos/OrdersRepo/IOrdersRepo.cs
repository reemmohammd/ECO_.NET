using ECommerce_2.DAL.Models;
using ECommerce_2.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL.Repos.OrdersRepo;

public interface IOrdersRepo : IGenericRepo<Order>
{
    void AddNewOrder(List<(int ProductId, int Quntity)> newOrder, string User2Id);
    IEnumerable<Order> GetAllOrder(string User2Id);
}
