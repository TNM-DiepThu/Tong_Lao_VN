using ASM_CS4.data;
using ASM_CS4.Models;
using ASM_CS4.Repository.IRepository;

namespace ASM_CS4.Repository.Repo
{
    public class CategoriesRepo : ICategoriesRepo
    {
        MyDbContext _dbContext;
        public CategoriesRepo(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(Categories p)
        {
            try
            {
                _dbContext.categories.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid p)
        {
            try
            {
                var cat = _dbContext.categories.Find(p);
                _dbContext.categories.Remove(cat);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Categories GetById(Guid id)
        {
            return _dbContext.categories.FirstOrDefault(p => p.Id == id);
        }

        public List<Categories> GetAll()
        {
            return _dbContext.categories.ToList();
        }

        public bool Update(Categories p)
        {
            try
            {
                var cat = _dbContext.categories.Find(p.Id);
                cat.name = p.name;
                cat.description = p.description;
                
                _dbContext.categories.Update(cat);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
