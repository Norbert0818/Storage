using CoreBuisness.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBuisness
{
    public class WorkerTask
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string WorkerId { get; set; }
        public string Description { get; set; }
        public DateTime AssignedDate { get; set; }
        public bool IsCompleted { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
