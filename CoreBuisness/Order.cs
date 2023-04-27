using CoreBuisness.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBuisness
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string CustomerId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        [Required(ErrorMessage = "Phone number is required")]
        public string CustomerPhoneNumber { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? WorkerName { get; set; }
        public string? WorkerPhoneNumber { get; set; }
        public double Qty { get; set; }
        public double? TotalPrice { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = null!;
        public DateTime DeliveryDay { get; set; } = DateTime.Now;
        public DateTime PickupDay { get; set; } = DateTime.Now;
        public int TaxNumber { get; set; }
        [Required(ErrorMessage = "Number of renting days is required")]
        public int DaysOfRenting { get; set; }
        public double TotalDiscount { get; set; }
        public int ShoppingCartId { get; set; }
        public OrderStatusEnum Status { get; set; }
        public string? OrderedProductNames { get; set; }
        [ForeignKey("ShoppingCartId")]
        public ShoppingCart? ShoppingCart { get; set; }
        //public ICollection<WorkerTask> Tasks { get; set; } = new List<WorkerTask>();
        //public ICollection<ShoppingCartProduct> OrderItems { get; set; } = new List<ShoppingCartProduct>();
    }
}
