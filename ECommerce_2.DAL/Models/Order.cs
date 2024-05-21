using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL.Models;

public class Order
{
    public int OrderId { get; set; }
    public List<OrderProduct> OrderItems { get; set; } = [];
    public DateTime OrderDate { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalPrice { get; set; }

    public string? User2Id { get; set; }
    public User2? User2 { get; set; }
    public ICollection<OrderProduct> ?OrderProducts { get; set; } 

}
