using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBuisness
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        [Required]
        public int MaxQuantity { get; set; }
        [Required]
        public double? Price { get; set; }
        public string? ImageLink { get; set; }
        public string? Description { get; set; }


        public List<ShoppingCartProduct> ShoppingCartProducts { get; set; } = new();

        // navigation property for ef core
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
