using Microsoft.EntityFrameworkCore.Storage;

using CG.DVDCentral.BL.Models;
using CG.DVDCentral.PL;

namespace CG.DVDCentral.BL
{
    public class MovieGenreManager
    {

        // Changed type from int to void
        public static void Insert(int movieId, int genreId, bool rollback = false) // Id by reference
        {
            try
            {

                /**/ // Dont know if this is right. Trying new method (this one is different to ProgDec MovieGenreManager)
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction? transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblMovieGenre entity = new tblMovieGenre();
                    entity.Id = dc.tblMovieGenres.Any() ? dc.tblMovieGenres.Max(s => s.Id) + 1 : 1;

                    entity.GenreId = genreId;
                    entity.MovieId = movieId;

                    // IMPORTANT - BACK FILL THE ID 
                    // Its not needed since we are not passing an object

                    dc.tblMovieGenres.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction?.Rollback();
                }
                //return results;
                /**/


                // Method to insert like ProgDec MovieGenreManager
                /*
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovieGenre tblMovieGenre = new tblMovieGenre();
                    tblMovieGenre.MovieId = movieId;
                    tblMovieGenre.GenreId = genreId;
                    tblMovieGenre.Id = dc.tblMovieGenres.Any() ? dc.tblMovieGenres.Max(sa => sa.Id) + 1 : 1;

                    dc.tblMovieGenres.Add(tblMovieGenre);
                    dc.SaveChanges();
                }
                */

            }
            catch (Exception) { throw; }
        }


        public static void Delete(int movieId, int genreId, bool rollback = false)
        {
            try
            {
                //int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblMovieGenre? tblMovieGenre = dc.tblMovieGenres.FirstOrDefault(sa => sa.MovieId == movieId && sa.GenreId == genreId);

                    if (tblMovieGenre != null)
                    {
                        dc.tblMovieGenres.Remove(tblMovieGenre);

                        //results = dc.SaveChanges();

                        dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                    if (rollback) transaction.Rollback();
                }

                //return results;


                // ------------------------------------------------- //
                /*
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovieGenre? tblMovieGenre = dc.tblMovieGenres
                                                            .FirstOrDefault(sa => sa.MovieId == movieId
                                                            && sa.GenreId == genreId);
                    if (tblMovieGenre != null)
                    {
                        dc.tblMovieGenres.Remove(tblMovieGenre);
                        dc.SaveChanges();
                    }

                }
                */


            }
            catch (Exception) { throw; }
        }

        // Not sure if update was needed here
        public static void Update(int movieId, int genreId, bool rollback = false)
        {
            try
            {
                //int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblMovieGenre? tblMovieGenre = dc.tblMovieGenres.FirstOrDefault(sa => sa.MovieId == movieId && sa.GenreId == genreId);
                    if (tblMovieGenre != null)
                    {
                        tblMovieGenre.MovieId = movieId;
                        tblMovieGenre.GenreId = genreId;

                        //results = dc.SaveChanges();
                        dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }

                    if (rollback) transaction.Rollback();
                }

                //return results;
            }
            catch (Exception) { throw; }
        }
    }
}
