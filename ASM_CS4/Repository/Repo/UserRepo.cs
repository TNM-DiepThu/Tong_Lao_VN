using ASM_CS4.data;
using ASM_CS4.Models;
using ASM_CS4.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ASM_CS4.Repository.Repo
{
    public class UserRepo : IUserRepo
    {
        MyDbContext _dbContext;
        public UserRepo(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(User p)
        {
            try
            {             
                Role customerRole = _dbContext.roles.FirstOrDefault(r => r.RoleName == "KhachHang");

                if (customerRole != null)
                {
                    p.RoleId = customerRole.Id;
                    _dbContext.Users.Add(p);
                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
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
                var cat = _dbContext.Users.Find(id);
                _dbContext.Users.Remove(cat);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(p => p.Id == id);
        }

        public bool Update(User p)
        {
            try
            {
                var cat = _dbContext.Users.Find(p.Id);
                cat.Username = p.Username;
                cat.Password = p.Password;
                cat.Status = p.Status;

                _dbContext.Users.Update(cat);
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
