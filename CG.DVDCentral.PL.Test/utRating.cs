
using CG.DVDCentral.PL.Test;

namespace CG.DVDCentral.PL.Test
{
    [TestClass]
    public class utRating : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 4;
            var ratings = dc.tblRatings;
            Assert.AreEqual(expected, ratings.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblRating newRow = new tblRating();

            newRow.Id = Guid.NewGuid();
            newRow.Description = "XXXXX";

            dc.tblRatings.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblRating row = dc.tblRatings.FirstOrDefault();

            if (row != null)
            {
                row.Description = "YYYYY";
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblRating row = dc.tblRatings.FirstOrDefault();

            if (row != null)
            {
                dc.tblRatings.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}
