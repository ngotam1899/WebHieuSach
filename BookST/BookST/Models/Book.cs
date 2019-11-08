using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public int Price { get; set; }       
        public Author Author { get; set; }
        public Source Source { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
