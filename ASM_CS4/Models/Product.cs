namespace ASM_CS4.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }    
        public string? Supplier { get; set; }
        public string? Description { get; set; }
        public string? UrlImage { get; set; }
        public int Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual List<Bill_Detail> BillDetails { get; set; }
        public virtual List<Cart_Detail> CartDetails { get; set; }      
        public Guid? idCat { get; set; }
        public virtual Categories? Categories { get; set; }
    }
}
