using ECommerce_2.DAL.Models;
using ECommerce_2.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL.Repos;

public interface ICartsRepo :IGenericRepo<Cart>
{
    void AddProductToCart(int productId, int Quentity, string UserId);
    void RemoveProductFromCart(int productId, string UserId);
    void UpadteProductQuentity(int productId, int Quentity, string UserId);
}
