using ASM_CS4.data;
using ASM_CS4.Models;
using ASM_CS4.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ASM_CS4.Repository.Repo
{
    public class CartRepo : ICartRepo
    {
        private readonly MyDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartRepo(MyDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;

        }
        public bool AddProductToCart(Guid userId, Guid productId, int quantity)
        {
            try
            {
                var cart = _dbContext.carts.Include(c => c.CartDetails).FirstOrDefault(c => c.UserId == userId);

                if (cart == null)
                {
                    cart = new Cart
                    {
                        UserId = userId,
                        Id = Guid.NewGuid(),
                        Description = "Initial Cart Description" // Thêm mô tả cho giỏ hàng nếu cần
                    };

                    cart.CartDetails = new List<Cart_Detail>(); // Khởi tạo danh sách chi tiết giỏ hàng
                    _dbContext.carts.Add(cart);
                    _dbContext.SaveChanges();
                }

                var cartDetail = cart.CartDetails.FirstOrDefault(cd => cd.IdSp == productId);

                if (cartDetail == null)
                {
                    cartDetail = new Cart_Detail
                    {
                        IdCart = userId,
                        IdSp = productId,
                        soluong = quantity,
                        status = 1 // Trạng thái chi tiết giỏ hàng
                    };
                    cart.CartDetails.Add(cartDetail);
                }
                else
                {
                    cartDetail.soluong += quantity;
                }

                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi, log lại hoặc thực hiện các hành động phù hợp
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public bool DeleteCart(Guid id)
        {
            try
            {
                var cat = _dbContext.Cart_Details.Find(id);
                _dbContext.Cart_Details.Remove(cat);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cart_Detail> GetCartDetailsByUserId(Guid userId)
        {
            return _dbContext.Cart_Details
         .Where(cd => cd.Cart.UserId == userId) // Lọc theo IdUser
         .Include(cd => cd.Product)
         .ToList();
        }
    }
}
