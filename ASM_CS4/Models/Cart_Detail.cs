namespace ASM_CS4.Models
{
    public class Cart_Detail
    {
        public Guid Id { get; set; }
        public Guid IdCart { get; set; }
        public Guid IdSp { get; set; }
        public int soluong {  get; set; }
        public int status { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
