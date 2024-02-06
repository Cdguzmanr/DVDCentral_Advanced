using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CG.DVDCentral.BL.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
    }
}

