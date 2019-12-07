using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Shipments
    {
        public int ID { get; set; }
        [Display(Name = "Sales Person")]
        public string SalesPersonID { get; set; }

        [ForeignKey("SalesPersonID")]
        public virtual ApplicationUser SalesPerson { get; set; }
        public DateTime ShipmentDate { get; set; }
        [NotMapped]
        public DateTime ShipmentTime { get; set; }
        
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public bool isConfirmed { get; set; }
        
    }
}
