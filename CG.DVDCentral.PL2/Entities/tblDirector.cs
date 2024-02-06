using BDF.DVDCentral.PL2.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace CG.DVDCentral.PL2.Entities
{
    public class tblDirector : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<tblMovie> tblMovies { get; set; }
    }
}
