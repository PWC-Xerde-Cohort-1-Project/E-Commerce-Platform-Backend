using System.ComponentModel.DataAnnotations;

namespace eCommerce.Model
{
    public class ProductRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public decimal Rate { get; set; }
        public int Count { get; set; }

        public int CategoryId { get; set; }
    }
}
