using CG.DVDCentral.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DVDCentral.BL.Models
{
    public class Order
    {
        [DisplayName("Order #")]
        public Guid Id { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        [Required]
        public Guid CustomerId { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType("Date")]
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        public Guid UserId { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType("Date")]
        [DisplayName("Ship Date")]
        public DateTime ShipDate { get; set; }

        [Required]
        public List<OrderItem> OrderItems { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double SubTotal
        {
            get
            {
                return (double)this.OrderItems.Sum(oi => oi.Cost);
            }
        }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Tax { get { return SubTotal * .055; } }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get { return SubTotal + Tax; } }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("User Full Name")]
        public string UserFullName { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerFullName { get; set; }

    }
}
