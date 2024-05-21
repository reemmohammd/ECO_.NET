using ECommerce_2.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.BL.Dtos.Order;

public class GetOrderHistoryDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalPrice { get; set; }
}
