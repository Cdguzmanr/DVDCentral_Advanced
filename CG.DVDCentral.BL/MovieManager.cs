
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.BL;
using Microsoft.Extensions.Options;

namespace CG.DVDCentral.BL
{
    public class MovieManager : GenericManager<tblMovie>
    {
        public MovieManager(DbContextOptions<DVDCentralEntities> options) : base(options) { }


        public static string[,] ConvertData(List<Movie> movies)
        {
            string[,] data = new string[movies.Count + 1, 5];

            int counter = 0;

            data[counter, 0] = "Title";
            data[counter, 1] = "Director";
            data[counter, 2] = "Format";
            data[counter, 3] = "Rating";
            data[counter, 4] = "Quantity";

            counter++;

            foreach (Movie movie in movies)
            {
                data[counter, 0] = movie.Title;
                data[counter, 1] = movie.DirectorFullName;
                data[counter, 2] = movie.FormatDescription;
                data[counter, 3] = movie.RatingDescription;
                data[counter, 4] = movie.Quantity.ToString();
                counter++;
            }

            return data;
        }

        private static List<Genre> ConvertToGenres(ICollection<tblMovieGenre> moviegenres)
        {
            List<Genre> genres = new List<Genre>();
            foreach (tblMovieGenre mg in moviegenres)
            {
                genres.Add(new Genre { Id = mg.GenreId, Description = mg.Genre.Description });
            }
            return genres;
        }

        private static List<tblMovieGenre> ConvertToMovieGenres(Movie movie)
        {
            List<tblMovieGenre> moviegenres = new List<tblMovieGenre>();
            foreach (Genre g in movie.Genres)
            {
                moviegenres.Add(new tblMovieGenre { Id = Guid.NewGuid(), MovieId = movie.Id, GenreId = g.Id });
            }
            return moviegenres;
        }

        /// <summary>
        /// Gets all of the movies from the database and returns a list of the movies
        /// </summary>
        /// <returns>A list of all the movies in the database</returns>
        public List<Movie> Load(Guid? genreId = null)
        {
            List<Movie> movies = new List<Movie>();
            try
            {

                base.Load()
                    .Where(mg => mg.tblMovieGenres.Any(_ => _.GenreId == genreId) || (genreId == null))
                    .ToList()
                    .ForEach(d => movies.Add(
                        new Movie()
                        {
                            Id = d.Id,
                            Description = d.Description,
                            Title = d.Title,
                            Cost = d.Cost,
                            RatingId = d.RatingId,
                            FormatId = d.FormatId,
                            DirectorId = d.DirectorId,
                            Quantity = d.Quantity,
                            ImagePath = d.ImagePath,
                            RatingDescription = d.Rating.Description,
                            FormatDescription = d.Format.Description,
                            DirectorFullName = d.Director.LastName + ", " + d.Director.FirstName,
                            Genres = ConvertToGenres(d.tblMovieGenres.ToList())
                        }));

            }
            catch (Exception)
            {
                throw;
            }
            return movies;
        }

        public List<Movie> Load()
        {
            try
            {
                List<Movie> movies = new List<Movie>();

                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    movies = (from m in dc.tblMovies
                              join mr in dc.tblRatings on m.RatingId equals mr.Id
                              join md in dc.tblDirectors on m.DirectorId equals md.Id
                              join mf in dc.tblFormats on m.FormatId equals mf.Id
                              select new Movie
                              {
                                  Id = m.Id,
                                  Title = m.Title,
                                  Description = m.Description,
                                  Cost = m.Cost,
                                  RatingId = m.RatingId,
                                  FormatId = m.FormatId,
                                  DirectorId = m.DirectorId,
                                  Quantity = m.Quantity,
                                  ImagePath = m.ImagePath,
                                  RatingDescription = mr.Description,
                                  FormatDescription = mf.Description,
                                  DirectorFullName = md.LastName + ", " + md.FirstName,
                                  Genres = new GenreManager(options).Load(m.Id)
                              }
                              )
                              .OrderBy(m => m.Title)
                              .ToList();
                }
                return movies;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Movie LoadById(Guid id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    tblMovie row = dc.tblMovies.FirstOrDefault(m => m.Id == id);
                    if (row != null)
                    {
                        Movie movie = new Movie
                        {
                            Id = row.Id,
                            Title = row.Title,
                            Description = row.Description,
                            Cost = row.Cost,
                            RatingId = row.RatingId,
                            FormatId = row.FormatId,
                            DirectorId = row.DirectorId,
                            Quantity = row.Quantity,
                            ImagePath = row.ImagePath,
                            //DirectorFullName = DirectorManager.LoadById(row.DirectorId).FullName,
                            //FormatDescription = FormatManager.LoadById(row.FormatId).Description,
                            ///RatingDescription = RatingManager.LoadById(row.RatingId).Description,
                            Genres = new GenreManager(options).Load(row.Id)
                        };
                        return movie;
                    }
                    else
                    {
                        throw new Exception("Row not found");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Movie> LoadByGenre(Guid? genreId = null)
        {
            try
            {
                List<Movie> movies = new List<Movie>();

                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    movies = (from m in dc.tblMovies
                              join mg in dc.tblMovieGenres on m.Id equals mg.MovieId
                              join mr in dc.tblRatings on m.RatingId equals mr.Id
                              join md in dc.tblDirectors on m.DirectorId equals md.Id
                              join mf in dc.tblFormats on m.FormatId equals mf.Id
                              where mg.GenreId == genreId || genreId == null
                              select new Movie
                              {
                                  Id = m.Id,
                                  Title = m.Title,
                                  Description = m.Description,
                                  Cost = m.Cost,
                                  RatingId = m.RatingId,
                                  FormatId = m.FormatId,
                                  DirectorId = m.DirectorId,
                                  Quantity = m.Quantity,
                                  ImagePath = m.ImagePath,
                                  RatingDescription = mr.Description,
                                  FormatDescription = mf.Description,
                                  DirectorFullName = md.LastName + ", " + md.FirstName,
                              }
                              )
                              .Distinct()
                              .OrderBy(m => m.Title)
                              .ToList();
                }

                foreach (Movie movie in movies)
                {
                    movie.Genres = new GenreManager(options).Load(movie.Id);
                }

                return movies;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Insert(Movie movie, bool rollback = false)
        {
            try
            {
                int results = base.Insert(new tblMovie
                {
                    Id = Guid.NewGuid(),
                    Title = movie.Title,
                    Description = movie.Description,
                    Cost = movie.Cost,
                    RatingId = movie.RatingId,
                    FormatId = movie.FormatId,
                    DirectorId = movie.DirectorId,
                    Quantity = movie.Quantity,
                    ImagePath = movie.ImagePath,
                    tblMovieGenres = ConvertToMovieGenres(movie)
                }, rollback);
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Movie movie, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblMovie
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    Cost = movie.Cost,
                    RatingId = movie.RatingId,
                    FormatId = movie.FormatId,
                    DirectorId = movie.DirectorId,
                    Quantity = movie.Quantity,
                    ImagePath = movie.ImagePath,
                }, rollback);
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblMovie deleteRow = dc.tblMovies.FirstOrDefault(f => f.Id == id);

                    if (deleteRow != null)
                    {
                        // delete all the associated tblMovieGenre rows. 
                        var genres = dc.tblMovieGenres.Where(g => g.MovieId == id);
                        dc.tblMovieGenres.RemoveRange(genres);

                        // delete all the associated tblOrderItem rows. 
                        var orderItems = dc.tblOrderItems.Where(i => i.MovieId == id);
                        dc.tblOrderItems.RemoveRange(orderItems);

                        // remove the movie
                        dc.tblMovies.Remove(deleteRow);

                        // Commit the changes and get the number of rows affected
                        results = dc.SaveChanges();

                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
