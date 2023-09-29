using CG.DVDCentral.BL.Models;

namespace CG.DVDCentral.BL.Test
{
    [TestClass]
    public class utRating
    {
        [TestMethod]
        public void LoadTest()
        { 
            Assert.AreEqual(3, RatingManager.Load().Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Rating rating = new Rating()
            {
                Description = "Test"
            };

            int results = RatingManager.Insert(rating, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Rating rating = RatingManager.LoadById(3);
            rating.Description = "UpdateTest";
            int results = RatingManager.Update(rating, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = RatingManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}