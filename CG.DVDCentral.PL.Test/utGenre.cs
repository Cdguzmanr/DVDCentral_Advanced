

using CG.DVDCentral.PL.Test;

namespace CG.DVDCentral.PL.Test
{
    [TestClass]
    public class utGenre : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var genres = dc.tblGenres;
            Assert.AreEqual(expected, genres.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblGenre newRow = new tblGenre();

            newRow.Id = Guid.NewGuid();
            newRow.Description = "XXXX";

            dc.tblGenres.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblGenre row = dc.tblGenres.FirstOrDefault();

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

            tblGenre row = dc.tblGenres.FirstOrDefault();

            if (row != null)
            {
                dc.tblGenres.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}
