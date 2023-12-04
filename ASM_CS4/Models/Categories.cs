namespace ASM_CS4.Models
{
    public class Categories
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }       
        public ICollection<Product> products { get; set; }
    }
}
