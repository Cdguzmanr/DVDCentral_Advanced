#nullable disable

namespace CG.DVDCentral.PL2.Entities;

public class tblRating : IEntity
{ 
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<tblMovie> tblMovies { get; } // one to many retalionship
    public string SortField { get { return Description; } }
}
