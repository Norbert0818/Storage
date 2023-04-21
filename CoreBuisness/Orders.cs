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
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public string WorkerName { get; set; }
        public string WorkerPhoneNumber { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get { return Qty * UnitPrice; } }
        public string Adress { get; set; }
        public DateTime DeliveryDay { get; set; }
        public DateTime PickupDay { get; set; }
        public int TaxNumber { get; set; }
        public int DaysOfRenting { get; set; }
        public double TotalDiscount;
        public object CartProducts;
    }
}
