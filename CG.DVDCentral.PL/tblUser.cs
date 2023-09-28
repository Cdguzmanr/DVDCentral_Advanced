using System;
using System.Collections.Generic;

namespace CG.DVDCentral.PL;

public partial class tblUser
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
