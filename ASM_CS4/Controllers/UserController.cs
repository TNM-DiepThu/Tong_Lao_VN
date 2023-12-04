using ASM_CS4.Models;
using ASM_CS4.Repository.IRepository;
using ASM_CS4.Repository.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ASM_CS4.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public IActionResult Index()
        {
            List<User> cat = _userRepo.GetAll();
            return View(cat);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User p)
        {
            if (_userRepo.Create(p))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid id) 
        {
            User p = _userRepo.GetById(id);
            return View(p);
        }

        public IActionResult Edit(User p) 
        {
            if (_userRepo.Update(p))
            {
                return RedirectToAction("Index");
            }
            else return View();
        }
        public IActionResult Delete(Guid id)
        {
            if (_userRepo.Delete(id))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
    }
}
