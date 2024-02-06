using BDF.DVDCentral.PL2.Entities;
using System;
using System.Collections.Generic;

namespace CG.DVDCentral.PL2.Entities;

public class tblFormat : IEntity
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<tblMovie> tblMovies { get; } // one to many retalionship
}
