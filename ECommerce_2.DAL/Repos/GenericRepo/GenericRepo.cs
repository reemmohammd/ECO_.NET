using ECommerce_2.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL.Repos.GenericRepo;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly AbilityContext _context;

    public GenericRepo(AbilityContext context)
    {
       this._context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().AsNoTracking();
    }

    //public T? GetById(int id)
    //{
    //    return _context.Set<T>().Find(id);
    //}

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Update(T entity)
    {

    }
}
