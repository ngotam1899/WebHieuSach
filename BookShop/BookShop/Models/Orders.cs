using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Orders
    {
        public int ID { get; set; }

        [Required]
        public DateTime Order_Date { get; set; }
        [Required]
        public string OrderFilled { get; set; }
        [Required]
        public string CreditCard { get; set; }
        public ICollection<OrderLines> OrderLines { get; set; }
        public Customers Customers { get; set; }
    }
}
