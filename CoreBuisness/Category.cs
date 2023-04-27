using System.ComponentModel.DataAnnotations;

namespace CoreBuisness
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        // navigation property for ef core
        public List<Product> Products { get; set; } = new();
    }
}