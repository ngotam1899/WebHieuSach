using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.ViewModel
{
    public class BooksViewModel
    {
        public Books Books { get; set; }
        public IEnumerable<BookTypes> BookTypes { get; set; }
        public IEnumerable<Authors> Authors { get; set; }
        public IEnumerable<Publishers> Publishers { get; set; }
    }
}
