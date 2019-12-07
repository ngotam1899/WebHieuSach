using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<Books> Books { get; set; }
        public Shipments Shipments { get; set; }
    }
}
