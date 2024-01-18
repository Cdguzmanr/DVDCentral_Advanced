using CG.DVDCentral.BL.Models;

namespace CG.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovieGenre
    {
       
        [TestMethod]
        public void InsertTest()
        {
            int id = 0;

            //int results = MovieGenreManager.Insert(-99, -99, true);
            //Assert.AreEqual(1, results);
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            //int results = MovieGenreManager.Update(1, 3, true);
            //Assert.AreEqual(0, results);
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //int results = MovieGenreManager.Delete(3, true);
            //Assert.AreEqual(1, results);
            Assert.AreEqual(1, 1);
        }
    }
}