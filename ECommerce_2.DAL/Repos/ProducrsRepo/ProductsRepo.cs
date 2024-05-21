using ECommerce_2.DAL.Context;
using ECommerce_2.DAL.Models;
using ECommerce_2.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace ECommerce_2.DAL.Repos.ProducrsRepo;

public class ProductsRepo : GenericRepo<Product>, IProductsRepo
{
    private readonly AbilityContext _Context;
    public ProductsRepo(AbilityContext context) : base(context)
    {
        _Context = context;
    }
    public IEnumerable<Product>? GetByCategory(int IdCat)
    {
        return _Context.Set<Product>().Where(x => x.CategoryId == IdCat);
    }

    public Product? GetById(int id)
    {
        return _Context.Set<Product>().Include(e => e.Category).FirstOrDefault(x => x.CategoryId == id);
    }

    public IEnumerable<Product>? GetByName(string Name)
    {
        return _Context.Set<Product>().Where(x => x.Name == Name);
    }


}
