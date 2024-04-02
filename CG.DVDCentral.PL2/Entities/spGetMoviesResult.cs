﻿#nullable disable

namespace CG.DVDCentral.PL2.Entities
{
    public class spGetMoviesResult : IEntity
    {
        public Guid Id { get; set; }
        public Guid DirectorId { get; set; }
        public Guid FormatId { get; set; }
        public Guid RatingId { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? RatingDescription { get; set; }
        public string? FormatDescription { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string SortField { get { return Title; } }
    }



}
