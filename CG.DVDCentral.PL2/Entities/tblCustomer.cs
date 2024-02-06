using CG.DVDCentral.PL2.Entities;
using System;
using System.Collections.Generic;

namespace CG.DVDCentral.PL2.Entities;

public class tblCustomer : IEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public Guid UserId { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string ZIP { get; set; } = null!;

    public string Phone { get; set; } = null!;

    //public string ImagePath { get; set; } = null!;

    public string State { get; set; } = null!;

    public virtual ICollection<tblOrder>? Orders { get; set; }
}
