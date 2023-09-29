using CG.DVDCentral.BL.Models;

namespace CG.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovie
    {
        [TestMethod]
        public void LoadTest()
        { 
            Assert.AreEqual(3, MovieManager.Load().Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Movie movie = new Movie()
            {
                Title = "Test",
                Description = "Test",
                FormatId = 1,
                DirectorId = 1,
                RatingId = 1,
                Cost = 1,
                InStkQty = 1,
                ImagePath = "Test"
        };

            int results = MovieManager.Insert(movie, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Movie movie = MovieManager.LoadById(3);
            movie.Title = "UpdateTest";
            int results = MovieManager.Update(movie, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = MovieManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}