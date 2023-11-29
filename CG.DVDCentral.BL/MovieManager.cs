using Microsoft.EntityFrameworkCore.Storage;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.PL;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace CG.DVDCentral.BL
{
    public class MovieManager
    {
        public static int Insert(Movie movie, bool rollback = false) // Id by reference
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblMovie entity = new tblMovie();
                    entity.Id = dc.tblMovies.Any() ? dc.tblMovies.Max(s => s.Id) + 1 : 1;
                    entity.Title = movie.Title;
                    entity.Description = movie.Description;
                    entity.FormatId = movie.FormatId;
                    entity.DirectorId = movie.DirectorId;
                    entity.RatingId = movie.RatingId;
                    entity.Cost = movie.Cost;
                    entity.InStkQty = movie.InStkQty;
                    entity.ImagePath = movie.ImagePath;

                    

                    // IMPORTANT - BACK FILL THE ID 
                    movie.Id = entity.Id;

                    dc.tblMovies.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception) { throw; }
        }

        public static int Update(Movie movie, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblMovie entity = dc.tblMovies.FirstOrDefault(s => s.Id == movie.Id);
                    if (entity != null)
                    {
                        entity.Title = movie.Title;
                        entity.Description = movie.Description;
                        entity.FormatId = movie.FormatId;
                        entity.DirectorId = movie.DirectorId;
                        entity.RatingId = movie.RatingId;
                        entity.Cost = movie.Cost;
                        entity.InStkQty = movie.InStkQty;
                        entity.ImagePath = movie.ImagePath;

                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }

                    if (rollback) transaction.Rollback();
                }

                return results;
            }
            catch (Exception) { throw; }
        }

        public static Movie LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //tblMovie entity = dc.tblMovies.FirstOrDefault(s => s.Id == id);

                    var entity = (from m in dc.tblMovies
                                  join mg in dc.tblMovieGenres on m.Id equals mg.MovieId
                                  join r in dc.tblRatings on m.RatingId equals r.Id
                                  join f in dc.tblFormats on m.FormatId equals f.Id
                                  join d in dc.tblDirectors on m.DirectorId equals d.Id
                                  where m.Id == id
                                  select new
                                  {
                                      m.Id,
                                      m.Title,
                                      m.Description,
                                      m.Cost,
                                      m.InStkQty,
                                      Rating = r.Description,
                                      Format = f.Description,
                                      DirectorFullName = d.FirstName + " " + d.LastName,
                                      m.ImagePath,
                                      Genres = GenreManager.Load(id)
                                  })
                                .FirstOrDefault();


                    if (entity != null)
                    {
                        return new Movie
                        {
                            Id = entity.Id,
                            Title = entity.Title,
                            Description = entity.Description,
                            Cost = entity.Cost,
                            InStkQty = entity.InStkQty,
                            RatingDescription = entity.Rating,
                            FormatDescription = entity.Format,
                            DirectorName = entity.DirectorFullName,
                            ImagePath = entity.ImagePath,
                            Genres = entity.Genres
                        };
                    }
                    else { throw new Exception(); }
                }
            }
            catch (Exception) { throw; }
        }

        public static List<Movie> Load(int? genreId = null)
        {

            // Test
            try
            {
                List<Movie> list = new List<Movie>();
                using (DVDCentralEntities dc = new DVDCentralEntities()) // Blocked Scope
                {
                    (from m in dc.tblMovies
                     join mg in dc.tblMovieGenres on m.Id equals mg.MovieId
                     join r in dc.tblRatings on m.RatingId equals r.Id
                     join f in dc.tblFormats on m.FormatId equals f.Id
                     join d in dc.tblDirectors on m.DirectorId equals d.Id
                     where mg.GenreId == genreId || genreId == null
                     select new
                     {
                         m.Id,
                         m.Title,
                         m.Description,
                         m.Cost,
                         m.InStkQty,
                         Rating = r.Description,
                         Format = f.Description,
                         DirectorFullName = d.FirstName + " " + d.LastName,
                         m.ImagePath,

                     })
                    .Distinct()
                    .ToList()
                    .ForEach(movie => list.Add(new Movie
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        Description = movie.Description,
                        Cost = movie.Cost,
                        InStkQty = movie.InStkQty,
                        RatingDescription = movie.Rating,
                        FormatDescription = movie.Format,
                        DirectorName = movie.DirectorFullName,
                        ImagePath = movie.ImagePath
                    }));
                }
                return list;
            }
            catch (Exception) { throw; }


            /* // Code with Ryan
            try
            {
                List<Movie> list = new List<Movie>();
                using (DVDCentralEntities dc = new DVDCentralEntities()) // Blocked Scope
                {
                    var test = (from m in dc.tblMovies
                                 join mg in dc.tblMovieGenres on m.Id equals mg.MovieId
                                 join r in dc.tblRatings on m.RatingId equals r.Id
                                 join f in dc.tblFormats on m.FormatId equals f.Id
                                 join d in dc.tblDirectors on m.DirectorId equals d.Id
                                 where mg.GenreId == genreId || genreId == null
                                 select new
                                 {
                                     m.Id,
                                     m.Title,
                                     m.Description,
                                     m.Cost,
                                     m.InStkQty,
                                     Rating = r.Description,
                                     Format = f.Description,
                                     DirectorFullName = d.FirstName + " " + d.LastName,
                                     m.ImagePath,

                                 });
                    // Divided this in two so I could debug it. 
                    test.ToList()
                    .ForEach(movie => {

                        Movie? existing = list.Find(x => x.Id == movie.Id);
                        if (existing == null)
                        {
                            existing = new Movie()
                            {
                                Id = movie.Id,
                                Title = movie.Title,
                                Description = movie.Description,
                                Cost = movie.Cost,
                                InStkQty = movie.InStkQty,
                                RatingDescription = movie.Rating,
                                FormatDescription = movie.Format,
                                DirectorName = movie.DirectorFullName,
                                ImagePath = movie.ImagePath
                            };

                            list.Add(existing);
                        }
                    });
                }
                return list;
            }
            catch (Exception) { throw; }
            */

        }

        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblMovie entity = dc.tblMovies.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.tblMovies.Remove(entity);

                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                    if (rollback) transaction.Rollback();
                } 
                return results;
            }
            catch (Exception) { throw; }
        }
    }
}
