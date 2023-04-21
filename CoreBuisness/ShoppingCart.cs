using System.ComponentModel.DataAnnotations;

namespace CoreBuisness
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public List<ShoppingCartProduct> CartProducts { get; set; }

        public ShoppingCart()
        {
            CartProducts = new List<ShoppingCartProduct>();
        }
        public bool IsEmpty()
        {
            return !this.CartProducts.Any();
        }
    }

    public class ShoppingCartProduct
    {
        [Key]
        public int Id { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int? OrderId { get; set; }//remove this and new migration needed
        public virtual Orders Order { get; set; }
    }
}