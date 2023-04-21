using CoreBuisness.User;
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
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public string WorkerName { get; set; }
        public string WorkerPhoneNumber { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string OrderItem { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get { return Qty * UnitPrice; } }
        public string Address { get; set; }
        public DateTime DeliveryDay { get; set; } = DateTime.Now;
        public DateTime PickupDay { get; set; } = DateTime.Now;
        public int TaxNumber { get; set; }
        public int DaysOfRenting { get; set; }
        public double TotalDiscount;
        public ICollection<ShoppingCartProduct> OrderItems { get; set; } = new List<ShoppingCartProduct>();
    }
}
