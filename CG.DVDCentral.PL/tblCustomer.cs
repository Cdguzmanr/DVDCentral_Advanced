using System;
using System.Collections.Generic;

namespace CG.DVDCentral.PL;

public partial class tblCustomer
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
}
