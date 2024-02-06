using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CG.DVDCentral.BL.Models;
namespace CG.DVDCentral.BL.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Genres = new List<Genre>();
        }

        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required]
        public double Cost { get; set; }

        [Required]
        public Guid RatingId { get; set; }

        [Required]
        public Guid FormatId { get; set; }

        [Required]
        public Guid DirectorId { get; set; }

        [DisplayName("In Stk Qty")]
        [Required]
        public int Quantity { get; set; }

        [DisplayName("File Name")]
        [Required(ErrorMessage = "Please select a movie poster file.")]
        public string ImagePath { get; set; }


        [DisplayName("Director")]
        public string DirectorFullName { get; set; }
        [DisplayName("Rating")]
        public string RatingDescription { get; set; }
        [DisplayName("Format")]
        public string FormatDescription { get; set; }


        public List<Genre> Genres { get; set; }

        [DisplayName("Genres")]
        public string GenreList
        {
            get
            {
                string genreList = string.Empty;
                Genres.ForEach(a => genreList += a.Description + ", ");

                if (!string.IsNullOrEmpty(genreList))
                {
                    genreList = genreList.Substring(0, genreList.Length - 2);

                }
                return genreList;
            }

        }


    }

}
