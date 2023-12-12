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
        public int Id { get; set; }

        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }
        
        [DisplayName("User ID")]
        public int UserId { get; set; }

        [DisplayName("Ship Date")]
        public DateTime ShipDate { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

// Note: OrderTaxes and OrderTotal SHOULD NOT be a calculated field. This should come from shopping cart and stored in the database.
// This because taxes could change during time, and the orders should stay the same.
// We did it this way since we didn't have the field in database and creating it would take too much extra effort.

        [DisplayName("Sub Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double SubTotal { get { return OrderItems.Sum(m => m.Cost); } }
        [DisplayName("Taxes")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? OrderTaxes { get { return (OrderItems.Sum(m => m.Cost)) * .055; } }

        [DisplayName("Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? OrderTotal { get { return (OrderItems.Sum(m => m.Cost)) + OrderTaxes; } }


        // Add User and Customer properties

        [DisplayName("Username")]
        public string? UserName { get; set; }

        [DisplayName("User First Name")]
        public string? UserFirstName { get; set; }

        [DisplayName("User Last Name")]
        public string? UserLastName { get; set; }

        [DisplayName("User Full Name")]
        public string? UserFullName { get { return UserLastName + ", " + UserFirstName; } }

        [DisplayName("Customer Name")]
        public string? CustomerFirstName { get; set; }

        [DisplayName("Customer Last Name")]
        public string? CustomerLastName { get; set; }

        [DisplayName("Customer Full Name")] 
        public string? CustomerFullName { get { return CustomerLastName + ", " + CustomerFirstName; } } 



    }
}
