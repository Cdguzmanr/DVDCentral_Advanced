using CG.DVDCentral.PL2.Entities;
using System;
using System.Collections.Generic;

namespace CG.DVDCentral.PL2.Entities;

public class tblOrder : IEntity
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public Guid UserId { get; set; }

    public DateTime ShipDate { get; set; }
}
