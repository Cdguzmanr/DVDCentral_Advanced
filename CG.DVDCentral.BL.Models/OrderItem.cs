using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DVDCentral.BL.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [DisplayName("Order Id")]
        public int OrderId { get; set; }

        [DisplayName("Movie Id")]
        public int MovieId { get; set; }
        
        public int Quantity { get; set; }
        
        [DisplayName("Total Cost")]
        public double Cost { get; set; }

    }
}
