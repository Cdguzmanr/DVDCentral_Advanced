
namespace CG.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovieGenre : utBase
    {

        [TestMethod]
        public void InsertTest()
        {
            Guid movieId = new MovieManager(options).Load().FirstOrDefault().Id;
            Guid genreId = new GenreManager(options).Load().FirstOrDefault().Id;
            int result = new MovieGenreManager(options).Insert(movieId, genreId, true);
            Assert.IsTrue(result > 0);
        }

        //[TestMethod]
        //public void DeleteTest()
        //{
        //    int movieGenreId = new MovieGenreManager(options).Load().FirstOrDefault().Id; 
        //    Assert.IsTrue(MovieGenreManager.Delete(movieGenreId, true) > 0);
        //}

        [TestMethod]
        public void DeleteTest2()
        {
            tblMovieGenre row = new MovieGenreManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new MovieGenreManager(options).Delete(row.MovieId, row.GenreId, true) > 0);
        }

    }
}
