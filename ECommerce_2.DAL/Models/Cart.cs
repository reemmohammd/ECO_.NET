using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL.Models;

public class Cart
{
    public int Id { get; set; }
    public string? User2Id { get; set; }
    public User2? User2 { get; set; }
    public ICollection<CartProduct> ?CartProducts { get; set; }
}