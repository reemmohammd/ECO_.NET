using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL.Repos.GenericRepo;

public interface IGenericRepo<T> where T : class
{
    IEnumerable<T> GetAll();
    //T? GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    int SaveChanges();
}
