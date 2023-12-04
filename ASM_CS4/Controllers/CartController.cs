using ASM_CS4.Repository.IRepository;
using ASM_CS4.Repository.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ASM_CS4.Controllers
{
    public class CartController : Controller
    {
        private ICartRepo _cartService;

        public CartController(ICartRepo cartRepo)
        {
            _cartService = cartRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCart([FromForm] Guid productId, [FromForm] int quantity)
        {
            var loggedInUserId = HttpContext.Session.GetString("UserId");
            if (loggedInUserId == null || !Guid.TryParse(loggedInUserId, out Guid userId))
            {
                return BadRequest("User is not logged in or session data is invalid.");
            }

            var success = _cartService.AddProductToCart(userId, productId, quantity);

            if (success)
            {
                TempData["CartMessage"] = "Product added to cart successfully";
                return RedirectToAction("CartDetails");
            }
            else
            {
                TempData["CartMessage"] = "Failed to add product to cart";
                return RedirectToAction("Details", new { id = productId });
            }
        }
        public IActionResult CartDetails()
        {
            var loggedInUserId = HttpContext.Session.GetString("UserId");
            if (loggedInUserId == null || !Guid.TryParse(loggedInUserId, out Guid userId))
            {
                return BadRequest("User is not logged in or session data is invalid.");
            }

            var cartDetails = _cartService.GetCartDetailsByUserId(userId);

            return View(cartDetails);
        }
        public IActionResult DeleteCart(Guid id)
        {
            if (_cartService.DeleteCart(id))
            {
                return RedirectToAction("CartDetails");
            }
            else return BadRequest();
        }


    }
}
