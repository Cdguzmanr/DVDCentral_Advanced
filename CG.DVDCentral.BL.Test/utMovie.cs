using CG.Reporting;

namespace CG.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovie : utBase
    {
        [TestMethod] public void utReportTest()
        {
            var movies = new MovieManager(options).Load();
            Excel.Export("Movies.xlsx", MovieManager.ConvertData(movies));
        }

        [TestMethod]
        public void LoadSPTest()
        {
            //var movies = new MovieSPManager(options).Load();
            // OR
            var movies = new MovieSPManager(options).Load("spGetMovies");
            int expected = 7;

            Assert.AreEqual(expected, movies.Count);
        }



        [TestMethod]
        public void LoadTest()
        {
            List<Movie> movies = new MovieManager(options).Load();
            int expected = 7;

            Assert.AreEqual(expected, movies.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Movie movie = new Movie
            {
                Id = Guid.NewGuid(),
                Title = "XXXXX",
                Description = "XXXXX",
                Cost = 9.99,
                RatingId = new RatingManager(options).Load().FirstOrDefault().Id,
                FormatId = new FormatManager(options).Load().FirstOrDefault().Id,
                DirectorId = new DirectorManager(options).Load().FirstOrDefault().Id,
                Quantity = 0,
                ImagePath = "XXXXXXX"
            };

            int result = new MovieManager(options).Insert(movie, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Movie movie = new MovieManager(options).Load().FirstOrDefault();
            movie.Title = "Blah blah blah";

            Assert.IsTrue(new MovieManager(options).Update(movie, true) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Movie movie = new MovieManager(options).Load().FirstOrDefault();

            Assert.IsTrue(new MovieManager(options).Delete(movie.Id, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Movie movie = new MovieManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new MovieManager(options).LoadById(movie.Id).Id, movie.Id);
        }


    }
}
