using ECommerce_2.DAL.Context;
using ECommerce_2.DAL.Models;
using ECommerce_2.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL.Repos;

public class CartsRepo : GenericRepo<Cart>, ICartsRepo

{
    public readonly AbilityContext _Context;
    public CartsRepo(AbilityContext Context) : base(Context)
    {
        _Context = Context;
    }

    public void AddProductToCart(int productId, int Quentity, string User2Id)
    {

        var cart = _Context.Set<Cart>()
                  .FirstOrDefault(c => c.User2Id == User2Id);

        if (cart == null)
        {
            // Create a new cart if it doesn't exist for the user
            cart = new Cart
            {
                User2Id = User2Id,
                CartProducts = new List<CartProduct>()
            };
            _Context.Set<Cart>().Add(cart);
            _Context.SaveChanges();
        }

        // Create a new cart item based on the provided productId and quantity
        var product = _Context.Products.Find(productId);
        if (product != null)
        {

            var cartItem = _Context.Set<CartProduct>().FirstOrDefault(item => item.ProductId == productId && item.CartId == cart.Id);
            if (cartItem != null)
            {
                cartItem.Quantity += Quentity;
            }
            else
            {
                var newcartItem = new CartProduct
                {
                    ProductId = productId,
                    Quantity = Quentity,
                    CartId = cart.Id
                };

                _Context.Set<CartProduct>().Add(newcartItem);
                _Context.SaveChanges();


            }

        }

        _Context.SaveChanges();

    }

    public void RemoveProductFromCart(int productId, string User2Id)
    {

        var cart = _Context.Set<Cart>()
                    .FirstOrDefault(c => c.User2Id == User2Id);

        if (cart != null)
        {
            var cartItem = _Context.Set<CartProduct>().FirstOrDefault(item => item.CartId == cart.Id && item.ProductId == productId);
            if (cartItem != null)
            {
                _Context.Set<CartProduct>().Remove(cartItem);
                _Context.SaveChanges();
            }
        }

    }

    public void UpadteProductQuentity(int productId, int Quentity, string User2Id)
    {
        //var userId = UserId;
        var cart = _Context.Set<Cart>()
                  .FirstOrDefault(c => c.User2Id == User2Id);
        if (cart != null)
        {
            var cartItem = _Context.Set<CartProduct>().FirstOrDefault(item => item.ProductId == productId && item.CartId == cart.Id);
            if (cartItem != null)
            {
                cartItem.Quantity = Quentity;

                _Context.SaveChanges();
            }

        }

    }
}
