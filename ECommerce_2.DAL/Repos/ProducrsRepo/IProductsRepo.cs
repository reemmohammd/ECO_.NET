using ECommerce_2.DAL.Models;
using ECommerce_2.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL.Repos.ProducrsRepo;

public interface IProductsRepo :IGenericRepo<Product>
{
    Product? GetById(int id);
    IEnumerable<Product>? GetAll();
    IEnumerable<Product>? GetByName(string Name);
    IEnumerable<Product>? GetByCategory(int IdCat);
}
