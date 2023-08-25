using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext db) : base(db)
    {
    }

    public void Update(Product product)
    {
        var objFromDb = _db.Products.FirstOrDefault(u => u.Id == product.Id);
        if (objFromDb != null)
        {
            objFromDb.Title = product.Title;
            objFromDb.ISBN = product.ISBN;
            objFromDb.Price = product.Price;
            objFromDb.PriceFor50 = product.PriceFor50;
            objFromDb.PriceFor100 = product.PriceFor100;
            objFromDb.ListPrice = product.ListPrice;
            objFromDb.Description = product.Description;
            objFromDb.CategoryId = product.CategoryId;
            objFromDb.Author = product.Author;
            if(product.ImageURL != null)
            {
                objFromDb.ImageURL = product.ImageURL;
            }

        }
    }
}