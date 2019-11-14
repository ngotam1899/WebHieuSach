using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Authors
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        public ICollection<Books> Books { get; set; }
    }
}
