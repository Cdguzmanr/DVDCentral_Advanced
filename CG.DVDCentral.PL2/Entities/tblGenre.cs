#nullable disable

namespace CG.DVDCentral.PL2.Entities;

public class tblGenre : IEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; } = null!;

    public virtual ICollection<tblMovieGenre> tblMovieGenres { get; }
    public string SortField { get { return Description; } }
}
