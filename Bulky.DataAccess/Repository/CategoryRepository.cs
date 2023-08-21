using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(Data.ApplicationDbContext db) : base(db)
    {
    }

    public void Update(Category category)
    {
        _db.Categories.Update(category);
    }

}