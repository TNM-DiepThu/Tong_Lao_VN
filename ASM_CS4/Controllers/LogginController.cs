using ASM_CS4.data;
using ASM_CS4.Models;
using ASM_CS4.ViewModal;
using Microsoft.AspNetCore.Mvc;

namespace ASM_CS4.Controllers
{
    public class Loggin : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        MyDbContext _dbContext;
        public Loggin(MyDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
    
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("Username", user.Username);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("Username");

            return RedirectToAction("Index", "Home");
        }
     
    }
}
