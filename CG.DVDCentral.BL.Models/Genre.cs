using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CG.DVDCentral.PL;

namespace CG.DVDCentral.BL.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public Genre()
        {

        }

        public Genre(Guid id, string description)
        {
            Id = id;
            Description = description;
        }


    }
}



