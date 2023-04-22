using CoreBuisness.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBuisness
{
    public class Orders
    {
        [Key]
        public int OrderNumber { get; set; }
        public string CustomerId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public string WorkerName { get; set; }
        public string WorkerPhoneNumber { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        public string CustomerPhoneNumber { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get { return Qty * UnitPrice; } }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        public DateTime DeliveryDay { get; set; } = DateTime.Now;
        public DateTime PickupDay { get; set; } = DateTime.Now;
        public int TaxNumber { get; set; }
        [Required(ErrorMessage = "Number of renting days is required")]
        public int DaysOfRenting { get; set; }
        public double TotalDiscount { get; set; }
        public int ShoppingCartId { get; set; }
        public ICollection<ShoppingCartProduct> OrderItems { get; set; } = new List<ShoppingCartProduct>();
    }
}
