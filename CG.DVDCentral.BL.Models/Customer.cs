﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DVDCentral.BL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int UserId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZIP { get; set; }
        public string? Phone { get; set; }
        public string? ImagePath { get; set; }
        public string? State { get; set; }

        // Read-Only field
        [DisplayName("Full Name")]
        public string? FullName { get { return $"{FirstName} {LastName}"; } }



    }
}
