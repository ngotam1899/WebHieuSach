using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.ViewModel
{
    public class ShipmentDetailsViewModel
    {
        public Shipments Shipment { get; set; }
        public List<ApplicationUser> SalesPerson { get; set; }
        public List<Books> Books { get; set; }
    }
}
