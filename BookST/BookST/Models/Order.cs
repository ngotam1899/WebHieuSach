using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Order
    {
        public int ID { get; set; }

        [Required]
        public DateTime Order_Date { get; set; }
        [Required]
        public string OrderFilled { get; set; }
        [Required]
        public string CreditCard { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
        public Customer Customer { get; set; }

    }
}
