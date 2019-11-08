using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
