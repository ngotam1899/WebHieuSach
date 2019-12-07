using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class BooksSelectedForShipment
    {
        public int ID { get; set; }
        public int ShipmentID { get; set; }
        [ForeignKey("ShipmentID")]
        public virtual Shipments Shipments { get; set; }
        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public virtual Books Books { get; set; }
    }
}
