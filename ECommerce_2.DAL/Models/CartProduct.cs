using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL.Models;
[PrimaryKey(nameof(CartId), nameof(ProductId))]
public class CartProduct
{
    public int CartId { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public Cart? Cart { get; set; }
    public Product? Product { get; set; }
}
