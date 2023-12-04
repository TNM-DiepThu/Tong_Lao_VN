using ASM_CS4.Models;

namespace ASM_CS4.Repository.IRepository
{
    public interface IUserRepo
    {
        public List<User> GetAll();
        public bool Create(User p);
        public bool Update(User p);
        public bool Delete(Guid id);
        public User GetById(Guid id);
    }
}
