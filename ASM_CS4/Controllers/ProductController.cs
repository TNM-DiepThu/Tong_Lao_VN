using ASM_CS4.Models;
using ASM_CS4.Repository.IRepository;
using ASM_CS4.Repository.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASM_CS4.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _productServices;
        public ProductController(IProductRepo product)
        {
            _productServices = product;
        }
        public IActionResult Index()
        {
            List<Product> cat = _productServices.GetAll();

            return View(cat);
        }
        [HttpGet]
        public IActionResult DSSP()
        {
            List<Product> cat = _productServices.GetAll();

            return View(cat);
        }

        public IActionResult Create() // Khi ấn vào Create thì hiển thị View
        {
            var categories = _productServices.GetCategories();
            ViewBag.Categories = categories.Select(c => new SelectListItem { Text = c.name, Value = c.Id.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product, [Bind] IFormFile imageFile) // Thực hiện chức năng thêm
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imgsp", fileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                    product.UrlImage = fileName;
                }
            }

            if (_productServices.Create(product))
            {
                return RedirectToAction("Index");
            }

            var categories = _productServices.GetCategories();
            ViewBag.Categories = categories;
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            if (_productServices.Delete(id))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Product p = _productServices.GetById(id);
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Product p, IFormFile imageFile)
        {

            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imgsp", imageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                    p.UrlImage = imageFile.FileName;
                }

                if (_productServices.Update(p, imageFile))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Details(Guid id)
        {
            var product = _productServices.GetById(id);
            if (product == null)
            {
                return NotFound(); // Xử lý nếu không tìm thấy sản phẩm
            }

            return View(product); // Trả về view hiển thị chi tiết sản phẩm
        }


    }
}

