using System;
using System.Collections.Generic;

namespace CG.DVDCentral.PL;

public partial class tblOrder
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public int UserId { get; set; }
}
