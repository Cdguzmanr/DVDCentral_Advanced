using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CG.DVDCentral.BL.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        [DisplayName("Order #")]
        public Guid OrderId { get; set; }
        public Guid MovieId { get; set; }
        public int Quantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Cost { get; set; }

        [DisplayName("Movie Title")]
        public string MovieTitle { get; set; }

        public string ImagePath { get; set; }
    }
}

