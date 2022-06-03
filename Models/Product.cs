using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
