namespace ASM_CS4.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Cart_Detail>? CartDetails { get; set; }
        public virtual User? User { get; set; }
    }
}
