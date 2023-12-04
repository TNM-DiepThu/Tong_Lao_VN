using ASM_CS4.Models;
using ASM_CS4.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ASM_CS4.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesRepo _categoriesRepo;
        public CategoriesController(ICategoriesRepo categories)
        {
            _categoriesRepo = categories;
        }
        public IActionResult Index()
        {
            List<Categories> cat = _categoriesRepo.GetAll();           
            return View(cat);
            //return View();
        }
        public IActionResult Create() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categories category)
        {
            if (_categoriesRepo.Create(category)) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid id) // Khi ấn vào Create thì hiển thị View
        {
            // Lấy Product từ database dựa theo id truyền vào từ route
            Categories p = _categoriesRepo.GetById(id);
            return View(p);
        }

        public IActionResult Edit(Categories p) // Thực hiện việc Tạo mới
        {
            if (_categoriesRepo.Update(p))
            {
                return RedirectToAction("Index");
            }
            else return View();
        }
        public IActionResult Delete(Guid id)
        {
            if (_categoriesRepo.Delete(id))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
    }
}
