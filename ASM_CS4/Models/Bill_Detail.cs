namespace ASM_CS4.Models
{
    public class Bill_Detail
    {
        public Guid Id { get; set; }
        public Guid IDHD { get; set; }
        public Guid IDSP { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}
