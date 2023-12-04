using ASM_CS4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASM_CS4.ViewModal
{
    public class CreateVM
    {
        public Product Product { get; set; }
        public SelectList CategoriesList { get; set; }
    }
}
