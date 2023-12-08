using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CG.DVDCentral.BL.Models
{
    public class ShoppingCart
    {
        // Taxes per movie
        const double TAX_VALUE = .055;

        public List<Movie> Items { get; set; } = new List<Movie>();
        public int NumberOfItems { get { return Items.Sum(m => m.Quantity); } }

        //public int Quantity { get; set; } // Should this be here? 

        [DisplayName("Sub Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double SubTotal { get { return Items.Sum(m => m.Cost * m.Quantity);  } }

        [DisplayName("Taxes")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Tax { get { return SubTotal * TAX_VALUE; } }

        [DisplayName("Total Cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get { return SubTotal + Tax; } }
    }
}

