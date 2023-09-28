using System;
using System.Collections.Generic;

namespace CG.DVDCentral.PL;

public partial class tblMovieGenre
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public int GenreId { get; set; }
}
