﻿using CG.DVDCentral.PL2.Entities;
using System;
using System.Collections.Generic;

namespace CG.DVDCentral.PL2.Entities;

public class tblGenre : IEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; } = null!;

    public virtual ICollection<tblMovieGenre> tblMovieGenres { get;}
}
