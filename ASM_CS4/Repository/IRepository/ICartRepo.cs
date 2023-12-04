using ASM_CS4.Models;

namespace ASM_CS4.Repository.IRepository
{
    public interface ICartRepo
    {
        public bool AddProductToCart(Guid userId, Guid productId, int quantity);
        public List<Cart_Detail> GetCartDetailsByUserId(Guid userId);
        public bool DeleteCart(Guid id);
    }
}
