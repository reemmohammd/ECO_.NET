using ECommerce_2.DAL.Context;
using ECommerce_2.DAL.Models;
using ECommerce_2.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL.Repos.OrdersRepo;

public class OrdersRepo : GenericRepo<Order>, IOrdersRepo
{
    public readonly AbilityContext _Context;

    public OrdersRepo(AbilityContext context) : base(context)
    {
        _Context = context;
    }

    public void AddNewOrder(List<(int ProductId, int Quntity)> newOrder, string User2Id)
    {
        var cart = _Context.Set<Cart>()
                  .FirstOrDefault(c => c.User2Id == User2Id);
        if (cart != null)
        {
            // Create a new order
            var order = new Order
            {
                OrderDate = DateTime.Now,
                User2Id = User2Id,

                OrderItems = new List<OrderProduct>()
            };
            _Context.Set<Order>().Add(order);
            _Context.SaveChanges();
            // Add order items from the provided list

            decimal total = 0;
            foreach (var obj in newOrder)
            {
                var product = _Context.Set<Product>().Find(obj.ProductId);
                if (product != null)
                {
                    var orderItem = new OrderProduct
                    {
                        ProductId = obj.ProductId,
                        Quantity = obj.ProductId,
                        OrderId = order.OrderId
                    };
                    _Context.Set<OrderProduct>().Add(orderItem);
                    total += obj.Quntity * (decimal)product.Price;

                    order.TotalPrice = total;
                    // Add the order to the context and save changes

                    _Context.SaveChanges();
                    var cartItem = cart?.CartProducts?.FirstOrDefault(e => e.ProductId == obj.ProductId);
                    if (cartItem != null)
                    {
                        cart?.CartProducts?.Remove(cartItem);
                        _Context.SaveChanges();
                    }

                }
            }
            _Context.SaveChanges();
        }

    }






    public IEnumerable<Order> GetAllOrder(string userId)
    {
        return _Context.Set<Order>()
           .Where(c => c.User2Id == userId);
    }
}
