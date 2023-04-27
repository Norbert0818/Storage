using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBuisness
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }

        public Order? Order { get; set; }
        public List<ShoppingCartProduct> ShoppingCartProducts { get; set; } = new();

        public bool IsEmpty()
        {
            return !ShoppingCartProducts.Any();
        }
    }


}