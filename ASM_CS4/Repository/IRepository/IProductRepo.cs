using ASM_CS4.Models;

namespace ASM_CS4.Repository.IRepository
{
    public interface IProductRepo
    {
        public List<Product> GetAll();
        public bool Create(Product p);
        public bool Update(Product p, IFormFile imageFile);
        public bool Delete(Guid id);
        public Product GetById(Guid id);
        public List<Categories> GetCategories();
    }
}
