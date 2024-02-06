using BDF.DVDCentral.PL2.Entities;
using System;
using System.Collections.Generic;

namespace CG.DVDCentral.PL2.Entities;

public class tblOrderItem : IEntity
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public int Quantity { get; set; }

    public Guid MovieId { get; set; }

    public double Cost { get; set; }
}
