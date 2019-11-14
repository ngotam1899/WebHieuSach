using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Books
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public int Price { get; set; }
        public Authors Authors { get; set; }
        public Sources Sources { get; set; }
        public Publishers Publishers { get; set; }
        public ICollection<OrderLines> OrderLines { get; set; }
    }
}
