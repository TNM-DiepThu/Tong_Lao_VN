using ASM_CS4.Models;

namespace ASM_CS4.Repository.IRepository
{
    public interface ICategoriesRepo
    {
        public List<Categories> GetAll();
        public bool Create(Categories p);
        public bool Update(Categories p);
        public bool Delete(Guid p);
        public Categories GetById(Guid id);
    }
}
