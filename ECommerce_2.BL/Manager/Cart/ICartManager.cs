using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.BL.Manager.Cart;

public interface ICartManager
{
    void AddProductToCart(int productId, int Quentity, string UserId);
    void RemoveProductFromCart(int productId, string UserId);
    void UpadteProductQuentity(int productId, int Quentity, string UserId);
}
