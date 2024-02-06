using CG.DVDCentral.PL2.Entities;
using System;
using System.Collections.Generic;

namespace CG.DVDCentral.PL2;

public class tblUser : IEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
