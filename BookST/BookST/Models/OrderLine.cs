using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class OrderLine
    {
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Cost_Line { get; set; }
        [Required]
        public string Shipped { get; set; }
        public Book Book { get; set; }
        public Order Order { get; set; }
    }
}
