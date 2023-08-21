using System.Linq.Expressions;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class 
{

    protected readonly Data.ApplicationDbContext _db;
    internal DbSet<T> dbSet;

    public Repository(Data.ApplicationDbContext db)
    {
        _db = db;
        this.dbSet = _db.Set<T>();
    }
    public IEnumerable<T> GetAll()
    {
        return dbSet.ToList();
    }

    public T? GetValueOrDefault(Expression<Func<T, bool>> filter)
    {
        return dbSet.Where(filter).FirstOrDefault();
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entity)
    {
        dbSet.RemoveRange(entity);
    }
}