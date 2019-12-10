using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Books
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string Image { get; set; }
        public bool Available { get; set; }

        [Display(Name = "Author")]
        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public virtual Authors Authors { get; set; }

        [Display(Name = "Publisher")]
        public int PublisherID { get; set; }

        [ForeignKey("PublisherID")]
        public virtual Publishers Publishers { get; set; }

        [Display(Name = "BookType")]
        public int BookTypeID { get; set; }
        [ForeignKey("BookTypeID")]
        public virtual BookTypes BookTypes { get; set; }
    }
}
