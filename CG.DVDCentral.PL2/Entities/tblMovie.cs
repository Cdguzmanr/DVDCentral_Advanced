#nullable disable

namespace CG.DVDCentral.PL2.Entities
{
    public class tblMovie : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public Guid RatingId { get; set; }
        public Guid FormatId { get; set; }
        public Guid DirectorId { get; set; }
        public virtual ICollection<tblMovieGenre> tblMovieGenres { get; set; }
        public virtual ICollection<tblOrderItem> OrderItems { get; set; } // Todo: Add this to the Manager Methods

        public virtual tblDirector Director { get; set; }
        public virtual tblRating Rating { get; set; }
        public virtual tblFormat Format { get; set; }
        public string SortField { get { return Title; } }

    }
}
