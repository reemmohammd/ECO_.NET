using ECommerce_2.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.BL.Dtos.Product;

public class GetProductDetailsDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    [Column(TypeName = "decimal(10,2)")]
    public float Price { get; set; }
    public string? Description { get; set; }
    public string? CategoryName { get; set; }

}
