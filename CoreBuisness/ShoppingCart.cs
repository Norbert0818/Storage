using System.ComponentModel.DataAnnotations;

namespace CoreBuisness
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<ShoppingCartProduct> CartProducts { get; set; }

        public bool IsEmpty()
        {
            return !this.CartProducts.Any();
        }
    }

    public class ShoppingCartProduct
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}