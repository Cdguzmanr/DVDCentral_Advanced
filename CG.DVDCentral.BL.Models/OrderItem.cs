using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Cost { get; set; } 

        [DisplayName("Movie Title")]
        public string? MovieTitle { get; set; } // Movie Title

        [DisplayName("Image")]
        public string ImagePath { get; set; } = "noImage.jpg";


    }
}
