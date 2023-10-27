using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DVDCentral.BL.Models
{
    public class Director
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        // Read-Only field
        [DisplayName("Full Name")]
        public string? FullName { get { return $"{FirstName} {LastName}"; } }

    }
}
