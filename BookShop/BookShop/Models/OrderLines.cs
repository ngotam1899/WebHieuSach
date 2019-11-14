using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class OrderLines
    {
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Cost_Line { get; set; }
        [Required]
        public string Shipped { get; set; }
        public Books Books { get; set; }
        public Orders Orders { get; set; }
    }
}
