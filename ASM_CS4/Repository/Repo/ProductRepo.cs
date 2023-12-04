using ASM_CS4.data;
using ASM_CS4.Models;
using ASM_CS4.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASM_CS4.Repository.Repo
{
    public class ProductRepo : IProductRepo
    {
        MyDbContext _dbContext;
        public ProductRepo(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(Product p)
        {
            try
            {

                _dbContext.products.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var cat = _dbContext.products.Find(id);
                _dbContext.products.Remove(cat);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAll()

        {
            var products = _dbContext.products.Include(p => p.Categories).ToList();
            return _dbContext.products.ToList();
        }

        public Product GetById(Guid id)
        {
            return _dbContext.products.FirstOrDefault(p => p.Id == id);
        }

        public bool Update(Product p, IFormFile imageFile)
        {
            try
            {
                var cat = _dbContext.products.Find(p.Id);
                cat.Name = p.Name;
                cat.Price = p.Price;
                cat.Quantity = p.Quantity;
                cat.Status = p.Status;
                cat.Supplier = p.Supplier;
                cat.Description = p.Description;
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Xử lý việc cập nhật ảnh
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imgsp", imageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                    cat.UrlImage = imageFile.FileName; // Cập nhật đường dẫn ảnh mới trong thông tin sản phẩm
                }

                _dbContext.products.Update(cat);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Categories> GetCategories()
        {
          
            var categories = _dbContext.categories.ToList(); 

            return categories;
        }
    }
}
