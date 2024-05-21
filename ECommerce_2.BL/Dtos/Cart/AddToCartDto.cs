using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.BL.Dtos.Cart;

public class AddToCartDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    
}
